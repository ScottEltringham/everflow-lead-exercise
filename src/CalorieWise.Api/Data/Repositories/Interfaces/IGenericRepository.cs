using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T, TId, TDbContext> :
    ICreateRepository<T, TDbContext>,
    IReadRepository<T, TId, TDbContext>,
    IUpdateRepository<T, TDbContext>,
    IDeleteRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
    }
}
