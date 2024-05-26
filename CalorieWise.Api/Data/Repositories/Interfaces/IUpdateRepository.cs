namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IUpdateRepository<T>
    {
        Task UpdateAsync(T entity);
    }
}
