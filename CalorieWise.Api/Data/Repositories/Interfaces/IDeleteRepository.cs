using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IDeleteRepository<TId, TDbContext> 
        where TId : struct 
        where TDbContext : DbContext
    {
        Task DeleteAsync(TId id);
    }
}
