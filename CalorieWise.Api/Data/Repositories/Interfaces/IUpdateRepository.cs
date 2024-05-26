using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IUpdateRepository<T, TDbContext> 
        where T : class 
        where TDbContext : DbContext
    {
        Task UpdateAsync(T entity);
    }
}
