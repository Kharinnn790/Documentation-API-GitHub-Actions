

using DataAccess.Repositories;
using Domain.Interfaces;
using Domain.Wrapper;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext DbContext;
        private IUserRepository _user;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(DbContext);
                }
                return _user;
            }
        }
        public RepositoryWrapper(AppDbContext dbContext) => DbContext = dbContext;
        public async Task Save() => await DbContext.SaveChangesAsync();
    }
}