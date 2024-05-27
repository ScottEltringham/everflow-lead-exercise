using FluentValidation;

namespace CalorieWise.Api.Features.Account.Login.V1
{
    public sealed class AccountLoginRequest
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }

    internal sealed class AccountLoginValidator : Validator<AccountLoginRequest>
    {
        public AccountLoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
