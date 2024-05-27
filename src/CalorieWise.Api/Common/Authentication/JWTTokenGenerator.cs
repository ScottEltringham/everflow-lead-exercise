using FastEndpoints.Security;

namespace CalorieWise.Api.Common.Authentication
{
    public class JWTTokenGenerator(IConfiguration configuration) : IJWTTokenGenerator
    {
        public string GenerateToken(string username)
        {
            var signingKey = configuration.GetValue<string>("JWTSigningKey") ?? throw new InvalidOperationException();

            var jwtToken = JwtBearer.CreateToken(
                o =>
                {
                    o.SigningKey = signingKey;
                    o.ExpireAt = DateTime.UtcNow.AddDays(1);
                    o.User.Claims.Add(("UserName", username));
                });

            return jwtToken;
        }
    }

    public interface IJWTTokenGenerator
    {
        string GenerateToken(string username);
    }
}
