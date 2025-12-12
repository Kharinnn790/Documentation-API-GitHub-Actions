using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository(AppDbContext DbContext) : RepositoryBase<User>(DbContext), IUserRepository
    {
    }
}