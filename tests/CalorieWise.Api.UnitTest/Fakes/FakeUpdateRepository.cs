using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeUpdateRepository<T, TId, TDbContext>(List<T> entities) : IUpdateRepository<T, TDbContext>
        where T : class, IEntity<TId>
        where TDbContext : DbContext
    {
        private readonly List<T> Entities = entities;

        public async Task UpdateAsync(T entity)
        {
            var toUpdate = Entities.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (toUpdate != null)
            {
                Entities.Remove(toUpdate);
                Entities.Add(entity);

                await Task.CompletedTask;
            }
        }
    }
}
