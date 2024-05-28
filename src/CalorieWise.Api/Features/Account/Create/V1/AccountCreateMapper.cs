using CalorieWise.Api.Common.Authentication;

namespace CalorieWise.Api.Features.Account.Create.V1
{
    public sealed class AccountCreateMapper : Mapper<AccountCreateRequest, AccountCreateResponse, Data.Models.Account>
    {
        public override Data.Models.Account ToEntity(AccountCreateRequest r)
        {
            return new Data.Models.Account() 
            {
                FirstName = r.FirstName,
                LastName = r.LastName,
                Username = r.Username,
                Password = PasswordHelper.HashPassword(r.Password),
                DateCreated = DateTime.UtcNow
            };
        }
    }
}