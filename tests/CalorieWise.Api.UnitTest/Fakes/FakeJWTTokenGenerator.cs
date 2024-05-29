using CalorieWise.Api.Common.Authentication;

namespace CalorieWise.Api.UnitTest.Fakes
{
    public class FakeJWTTokenGenerator : IJWTTokenGenerator
    {
        public string GenerateToken(string username)
        {
            return "mocked_token";
        }
    }
}
