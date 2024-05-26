using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Account.Create.V1
{
    public class AccountCreateService(ICreateRepository<Data.Models.Account, CalorieWiseDbContext> createRepository, IReadRepository<Data.Models.Account, long, CalorieWiseDbContext> readRepository) : IAccountCreateService
    {
        public async Task<bool> CreateNewAccount(Data.Models.Account account)
        {
            var userNameIsTaken = await UserNameIsTaken(account.Username);

            if (userNameIsTaken)
                return false;

            await createRepository.AddAsync(account);

            return true;
        }

        public async Task<bool> UserNameIsTaken(string lowerCaseUserName)
        {
            var account = await readRepository.GetAllAsync();
            return account.Any();
        }
    }
}
