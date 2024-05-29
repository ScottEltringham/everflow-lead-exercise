using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class DeleteRepository<TId, TDbContext>(TDbContext context) : IDeleteRepository<TId, TDbContext>
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly DbSet<object> _dbSet = context.Set<object>();

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
