namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface ICreateRepository<T, TDbContext>
    {
        Task AddAsync(T entity);
    }
}
