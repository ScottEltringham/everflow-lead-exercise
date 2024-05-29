using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeDeleteRepository<T, TId, TDbContext>(List<T> entities) : IDeleteRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly List<T> Entities = entities;

        public async Task DeleteAsync(TId id)
        {
            var entity = Entities.FirstOrDefault( x => x.Id.Equals(id));
            if (entity != null)
            {
                Entities.Remove(entity);
                await Task.CompletedTask;
            }
        }
    }
}
