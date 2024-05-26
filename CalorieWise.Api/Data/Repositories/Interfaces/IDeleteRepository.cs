using System.Security.Cryptography;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IDeleteRepository<TId>
    {
        Task DeleteAsync(TId id);
    }
}
