namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T, TId, TDbContext> :
    ICreateRepository<T, TDbContext>,
    IReadRepository<T, TId, TDbContext>,
    IUpdateRepository<T>,
    IDeleteRepository<TId>
    {
    }
}
