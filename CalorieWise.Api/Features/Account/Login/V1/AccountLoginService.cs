using CalorieWise.Api.Authentication;
using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;
using FastEndpoints.Security;

namespace CalorieWise.Api.Features.Account.Login.V1
{
    public class AccountLoginService(
        IConfiguration configuration,
        IReadRepository<Data.Models.Account, long, CalorieWiseDbContext> readRepository) : IAccountLoginService
    {
        public string VerifyAndGenerateJWTToken(AccountLoginRequest request)
        {
            if (CredentialsAreValid(request))
            {
                var signingKey = configuration.GetValue<string>("JWTSigningKey") ?? throw new InvalidOperationException();

                var jwtToken = JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = signingKey;
                    o.ExpireAt = DateTime.UtcNow.AddDays(1);
                    o.User.Claims.Add(("UserName", request.Username));
                });

                return jwtToken;
            }

            return String.Empty;
        }


        private bool CredentialsAreValid(AccountLoginRequest request)
        {
            var query = readRepository.GetAllQueryable();
            var user = query.FirstOrDefault( x => x.Username == request.Username);

            if (user == null) return false;

            return PasswordHelper.VerifyPassword(request.Password, user.Password);
        }
    }
}
