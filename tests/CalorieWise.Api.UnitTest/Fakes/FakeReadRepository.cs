using CalorieWise.Api.Data.Repositories.Interfaces;
using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeReadRepository(List<Account> accounts) : IReadRepository<Account, AccountId, CalorieWiseDbContext>
    {
        public async Task<Account?> GetByIdAsync(AccountId id)
        {
            await Task.CompletedTask;

            var account = accounts.FirstOrDefault(x => x.Id.Equals(id));
            return account;
        }

        public IQueryable<Account> GetAllQueryable(
            Expression<Func<Account, bool>>? filter = null,
            Func<IQueryable<Account>, IIncludableQueryable<Account, object>>? include = null)
        {
            IQueryable<Account> queryable = accounts.AsQueryable();

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