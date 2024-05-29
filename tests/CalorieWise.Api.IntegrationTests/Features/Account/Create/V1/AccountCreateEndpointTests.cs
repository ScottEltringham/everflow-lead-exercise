using CalorieWise.Api.Features.Account.Create.V1;
using CalorieWise.Api.IntegrationTests.Helpers;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;
using ProblemDetails = FastEndpoints.ProblemDetails;

namespace CalorieWise.Api.IntegrationTests.Features.Account.Create.V1
{
    public class AccountCreateEndpointTests(CalorieWiseApiFixture app) : TestBase<CalorieWiseApiFixture>
    {
        [Fact]
        public async Task AccountCreateEndpoint_ShouldReturnOk_WhenAccountIsCreated()
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
            dataResponse.Message.Should().Be("Account created AccountId { Value = 2 }");
        }

        [Fact]
        public async Task AccountCreateEndpoint_ShouldReturnProblemDetails_WhenUsernameAlreadyExists()
        {
            AccountCreateRequest request = new()
            {
                FirstName = "Duplicate",
                LastName = "Test",
                Username = "DuplicateTest",
                Password = "Test123!"
            };

            await app.Client.POSTAsync<AccountCreateEndpoint, AccountCreateRequest, AccountCreateResponse>(request);

            var (httpResponse, dataResponse) = await app.Client.POSTAsync<AccountCreateEndpoint, AccountCreateRequest, ProblemDetails>(request);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            dataResponse.Should().NotBeNull();
            dataResponse.Errors.Should().HaveCount(1);
            dataResponse.Errors.ToArray()[0].Reason.Should().Be("Username already exists");
        }
    }
}
