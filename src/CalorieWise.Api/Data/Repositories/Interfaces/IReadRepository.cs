using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IReadRepository<T, TId, TDbContext> 
        where T : class 
        where TId : struct 
        where TDbContext : DbContext
    {
        Task<T?> GetByIdAsync(TId id);

        IQueryable<T> GetAllQueryable(
             Expression<Func<T, bool>>? filter = null,
             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
    }
}
