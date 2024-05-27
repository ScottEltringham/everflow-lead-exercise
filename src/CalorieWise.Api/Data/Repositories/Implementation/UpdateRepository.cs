using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class UpdateRepository<T, TDbContext>(DbContext context) : IUpdateRepository<T, TDbContext> 
        where T : class
        where TDbContext : DbContext
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
