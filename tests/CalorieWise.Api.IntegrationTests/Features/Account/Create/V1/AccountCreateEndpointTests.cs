using CalorieWise.Api.IntegrationTests.Helpers;
using CalorieWise.Api.Features.Account.Create.V1;
using FastEndpoints.Testing;
using FluentAssertions;
using FastEndpoints;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Account.Create.V1
{
    public class AccountCreateEndpointTests(CalorieWiseApiFixture app) : TestBase<CalorieWiseApiFixture>
    {
        [Fact]
        public async Task CreateAccount_ShouldReturnOk_WhenAccountIsCreated()
        {
            var (httpResponse, dataResponse) = await app.Client.POSTAsync<AccountCreateEndpoint, AccountCreateRequest, AccountCreateResponse>(new()
                {
                    FirstName = "Test",
                    LastName = "Test",
                    Username = "TestTest",
                    Password = "Test123!"
                });

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            dataResponse.Should().NotBeNull();
            dataResponse.Message.Should().Be("Account created AccountId { Value = 0 }");
        }
    }
}
