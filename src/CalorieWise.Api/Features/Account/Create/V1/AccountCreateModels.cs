using FluentValidation;

namespace CalorieWise.Api.Features.Account.Create.V1
{
    internal sealed class AccountCreateRequest
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }

    internal class AccountCreateResponse
    {
        public string Message { get; set; } = string.Empty;
    }

    internal class AccountCreateValidator : Validator<AccountCreateRequest>
    {
        public AccountCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MinimumLength(5).WithMessage("Username must be at least 5 characters long")
                .MaximumLength(20).WithMessage("Username is too long");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[A-Za-z]").WithMessage("Password must contain at least one letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[!@#$%^&*(),.?:{ }|<>]").WithMessage("Password must contain at least one special character");
        }
    }
}
