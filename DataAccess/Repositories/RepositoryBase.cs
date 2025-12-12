using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext DbContext { get; set; }
        public RepositoryBase(AppDbContext dbContext) => DbContext = dbContext;
        public async Task<List<T>> FindAll() => await DbContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            await DbContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public async Task Create(T entity) => await DbContext.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => DbContext.Set<T>().Update(entity);
        public async Task Delete(T entity) => DbContext.Set<T>().Remove(entity);
    }
}