using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class CreateRepository<T, TDbContext> : ICreateRepository<T, TDbContext> 
        where T : class
        where TDbContext : DbContext
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public DbSet<T> DbSet => _dbSet;

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
