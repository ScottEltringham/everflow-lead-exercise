using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IDeleteRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct 
        where TDbContext : DbContext
    {
        Task DeleteAsync(TId id);
    }
}
