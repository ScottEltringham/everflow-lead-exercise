using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieWise.Api.Features.Account.Login.V1
{
    public sealed class AccountLoginEndpoint(IAccountLoginService service) : Endpoint<AccountLoginRequest, Results<Ok<AccountLoginResponse>, ProblemDetails>>
    {
        public override void Configure()
        {
            Post("/account/login");
            AllowAnonymous();
            Summary(s =>
            {
                s.ExampleRequest = new AccountLoginRequest { };
            });
        }

        public override async Task<Results<Ok<AccountLoginResponse>, ProblemDetails>> ExecuteAsync(AccountLoginRequest r, CancellationToken c)
        {
            var jwtToken = service.VerifyAndGenerateJWTToken(r);

            if (jwtToken != string.Empty)
            {
                return TypedResults.Ok(new AccountLoginResponse
                {
                    Username = r.Username,
                    Token = jwtToken
                });
            }

            AddError("The supplied credentials are invalid");
            return new ProblemDetails(ValidationFailures);
        }
    }
}