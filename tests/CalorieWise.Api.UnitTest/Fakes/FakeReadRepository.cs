using CalorieWise.Api.Data.Repositories.Interfaces;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeReadRepository<T, TId, TDbContext>(List<T> entities) : IReadRepository<T, TId, TDbContext>
        where T : class, IEntity<TId>
        where TId : struct
        where TDbContext : DbContext
    {
        private readonly List<T> Entities = entities;

        public async Task<T?> GetByIdAsync(TId id)
        {
            await Task.CompletedTask;

            var entity = Entities.FirstOrDefault(x => x.Id.Equals(id));
            return entity;
        }

        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null)
        {
            IQueryable<T> queryable = Entities.AsQueryable();

            queryable = queryable.AsNoTracking();
             
            if (include != null)
            {
                queryable = include(queryable);
            }

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            return queryable;
        }
    }
}