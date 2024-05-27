using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class CreateRepository<T, TDbContext>(TDbContext context) : ICreateRepository<T, TDbContext> 
        where T : class
        where TDbContext : DbContext
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public DbSet<T> DbSet => _dbSet;

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
