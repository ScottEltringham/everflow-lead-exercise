using CalorieWise.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeCreateRepository<T, TDbContext> : ICreateRepository<T, TDbContext>
        where T : class
        where TDbContext : DbContext
    {
        public List<T> Entities = [];

        public Task AddAsync(T entity)
        {
            Entities.Add(entity);
            return Task.CompletedTask;
        }
    }
}