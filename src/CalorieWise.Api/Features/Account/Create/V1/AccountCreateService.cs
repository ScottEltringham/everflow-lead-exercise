﻿using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Models;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Account.Create.V1
{
    public sealed class AccountCreateService(
        ICreateRepository<Data.Models.Account, CalorieWiseDbContext> createRepository, 
        IReadRepository<Data.Models.Account, AccountId, CalorieWiseDbContext> readRepository) : IAccountCreateService
    {
        public async Task<bool> CreateNewAccount(Data.Models.Account account)
        {
            var userNameIsTaken = UserNameIsTaken(account.Username.ToLower());

            if (userNameIsTaken)
                return false;

            await createRepository.AddAsync(account);

            return true;
        }

        public bool UserNameIsTaken(string lowerCaseUserName)
        {
            var query = readRepository.GetAllQueryable(x => x.Username.ToLower() == lowerCaseUserName);

            return query.ToList().Count > 0;
        }
    }
}
