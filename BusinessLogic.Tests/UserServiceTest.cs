
using Moq;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMock;
        public UserServiceTest()
        {
            var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            userRepositoryMock = new Mock<IUserRepository>();

            service = new UserService(repositoryWrapperMock.Object);
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never());
        }
        
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() 
                => service.Create(newUser));

            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never());
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            var newUser = new User()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test@email.com",
                CreatedDate = DateTime.Now
            };

            await service.Create(newUser);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once());
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new User() {FirstName = "", LastName = "", Email = "", CreatedDate = DateTime.Now}
                },
                new object[]
                {
                    new User(){FirstName = "", LastName = "", Email = "", CreatedDate = DateTime.Now}
                },
                new object[]
                {
                    new User() {FirstName = "", LastName = "", Email = "", CreatedDate = DateTime.Now}
                }
            };
        }
    }
}
