using CalorieWise.Api.Data.Repositories.Interfaces;
using CalorieWise.Api.Data;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeCreateRepository : ICreateRepository<Data.Models.Account, CalorieWiseDbContext>
    {
        public List<Data.Models.Account> Accounts = [];

        public Task AddAsync(Data.Models.Account account)
        {
            Accounts.Add(account);
            return Task.CompletedTask;
        }
    }
}