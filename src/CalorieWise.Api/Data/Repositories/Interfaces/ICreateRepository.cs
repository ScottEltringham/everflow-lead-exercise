using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface ICreateRepository<T, TDbContext> 
        where T : class 
        where TDbContext : DbContext
    {
        Task AddAsync(T entity);
    }
}
