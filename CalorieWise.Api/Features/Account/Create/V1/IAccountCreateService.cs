namespace CalorieWise.Api.Features.Account.Create.V1
{
    public interface IAccountCreateService
    {
        Task<bool> UserNameIsTaken(string lowerCaseUserName);
        Task<bool> CreateNewAccount(Data.Models.Account account);
    }
}
