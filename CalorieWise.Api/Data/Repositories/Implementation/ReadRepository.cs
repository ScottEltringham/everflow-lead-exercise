using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class ReadRepository<T, TId, TDbContext> : IReadRepository<T, TId, TDbContext> 
        where T : class
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public DbSet<T> DbSet => _dbSet;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
