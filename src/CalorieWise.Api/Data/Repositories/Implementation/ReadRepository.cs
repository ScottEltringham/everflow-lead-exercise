using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class ReadRepository<T, TId, TDbContext>(TDbContext context) : IReadRepository<T, TId, TDbContext> 
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly DbSet<T> _dbSet = context.Set<T>();

        public DbSet<T> DbSet => _dbSet;

        public IQueryable<T> GetAllQueryable(
             Expression<Func<T, bool>>? filter = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryable = _dbSet;

            queryable = queryable.AsNoTracking();

            if (include != null)
            {
                queryable = include(queryable);
            }

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            return queryable;
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
