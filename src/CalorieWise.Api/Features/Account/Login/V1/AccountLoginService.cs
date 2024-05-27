using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Account.Login.V1
{
    public class AccountLoginService(
        IJWTTokenGenerator jwtTokenGenerator,
        IReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext> readRepository) : IAccountLoginService
    {
        public string VerifyAndGenerateJWTToken(AccountLoginRequest request)
        {
            if (CredentialsAreValid(request))
            {
                return jwtTokenGenerator.GenerateToken(request.Username);
            }

            return String.Empty;
        }

        public bool CredentialsAreValid(AccountLoginRequest request)
        {
            var query = readRepository.GetAllQueryable();
            var user = query.FirstOrDefault( x => x.Username == request.Username);

            if (user == null) return false;

            return PasswordHelper.VerifyPassword(request.Password, user.Password);
        }
    }
}
