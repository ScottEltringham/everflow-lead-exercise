namespace CalorieWise.Api.Features.Account.Login.V1
{
    internal sealed class AccountLoginEndpoint(IAccountLoginService service) : Endpoint<AccountLoginRequest>
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

        public override async Task HandleAsync(AccountLoginRequest r, CancellationToken c)
        {
            var jwtToken = service.VerifyAndGenerateJWTToken(r);

            if (jwtToken != string.Empty)
            {
                await SendAsync(new
                {
                    r.Username,
                    Token = jwtToken
                });
            }

            ThrowError("The supplied credentials are invalid");
        }
    }
}