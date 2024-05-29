using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class DeleteRepository<T, TId, TDbContext>(TDbContext context) : IDeleteRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task DeleteAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
