using CalorieWise.Api.Common.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
