using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieWise.Api.Features.Account.Create.V1
{
    public sealed class AccountCreateEndpoint(IAccountCreateService service) : Endpoint<AccountCreateRequest, Results<Ok<AccountCreateResponse>, ProblemDetails>, AccountCreateMapper>
    {
        public override void Configure()
        {
            Post("/account/create");
            AllowAnonymous();
            Summary(s =>
            {
                s.ExampleRequest = new AccountCreateRequest { };
            });
        }

        public override async Task<Results<Ok<AccountCreateResponse>, ProblemDetails>> ExecuteAsync(AccountCreateRequest r, CancellationToken c)
        {
            var entity = Map.ToEntity(r);

            var accountCreated = await service.CreateNewAccount(entity);

            if (!accountCreated)
            {
                AddError("Username already exists");
                return new ProblemDetails(ValidationFailures);
            }

            return TypedResults.Ok(new AccountCreateResponse
            {
                Message = $"Account created { entity.Id }"
            });
        }
    }
}