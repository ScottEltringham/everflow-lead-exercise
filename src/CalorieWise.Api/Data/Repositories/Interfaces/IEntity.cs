namespace CalorieWise.Api.Data.Repositories.Interfaces
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
