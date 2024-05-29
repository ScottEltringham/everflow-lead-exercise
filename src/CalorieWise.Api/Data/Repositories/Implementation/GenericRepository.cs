using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class GenericRepository<T, TId, TDbContext>(
        ICreateRepository<T, TDbContext> createRepository,
        IReadRepository<T, TId, TDbContext> readRepository,
        IUpdateRepository<T, TDbContext> updateRepository,
        IDeleteRepository<TId, TDbContext> deleteRepository) : IGenericRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
        public async Task AddAsync(T entity)
        {
            await createRepository.AddAsync(entity);
        }

        public IQueryable<T> GetAllQueryable(
            Expression<Func<T, bool>>? filter = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            return readRepository.GetAllQueryable(filter, include);
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await readRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await updateRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TId id)
        {
            await deleteRepository.DeleteAsync(id);
        }
    }
}
