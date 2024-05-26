using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Implementation
{
    public class GenericRepository<T, TId, TDbContext>(
        ICreateRepository<T, TDbContext> createRepository,
        IReadRepository<T, TId, TDbContext> readRepository,
        IUpdateRepository<T> updateRepository,
        IDeleteRepository<TId> deleteRepository) : IGenericRepository<T, TId, TDbContext> where T : class where TDbContext : DbContext
    {
        public async Task AddAsync(T entity)
        {
            await createRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await readRepository.GetAllAsync();
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
