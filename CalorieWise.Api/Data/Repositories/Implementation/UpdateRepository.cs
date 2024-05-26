using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class UpdateRepository<T>(DbContext context) : IUpdateRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
