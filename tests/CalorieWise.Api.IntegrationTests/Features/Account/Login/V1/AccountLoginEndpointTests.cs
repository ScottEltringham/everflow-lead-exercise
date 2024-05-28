using CalorieWise.Api.Features.Account.Create.V1;
using CalorieWise.Api.Features.Account.Login.V1;
using CalorieWise.Api.IntegrationTests.Helpers;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Account.Login.V1
{
    public class AccountLoginEndpointTests(CalorieWiseApiFixture app) : TestBase<CalorieWiseApiFixture>
    {
        [Fact]
        public async Task AccountLoginEndpoint_ShouldReturnToken_WhenCredentialsAreValid()
        {
            var username = "TestTest";
            var password = "Test123!";

            await app.Client.POSTAsync<AccountCreateEndpoint, AccountCreateRequest, AccountCreateResponse>(new() {
                FirstName = "Test",
                LastName = "Test",
                Username = username,
                Password = password
            });

            var (httpResponse, dataResponse) = await app.Client.POSTAsync<AccountLoginEndpoint, AccountLoginRequest, AccountLoginResponse>(new()
            {
                Username = "TestTest",
                Password = password
            });

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            dataResponse.Should().NotBeNull();
            dataResponse.Username.Should().Be(username);
            dataResponse.Token.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task AccountLoginEndpoint_ShouldReturnError_WhenCredentialsAreInvalid()
        {
            var (httpResponse, dataResponse) = await app.Client.POSTAsync<AccountLoginEndpoint, AccountLoginRequest, ProblemDetails>(new()
            {
                Username = "invalidUser",
                Password = "invalidPassword"
            });

            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            dataResponse.Should().NotBeNull();
            dataResponse.Errors.ToArray()[0].Reason.Should().Be("The supplied credentials are invalid");
        }
    }
}
