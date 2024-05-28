namespace CalorieWise.Api.Features.Account.Login.V1
{
    public interface IAccountLoginService
    {
        string VerifyAndGenerateJWTToken(AccountLoginRequest request);
    }
}