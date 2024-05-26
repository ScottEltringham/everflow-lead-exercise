using System.Security.Cryptography;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IReadRepository<T, TId, TDbContext>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TId id);
    }
}
