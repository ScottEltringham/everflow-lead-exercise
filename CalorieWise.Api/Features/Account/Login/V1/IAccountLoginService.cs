namespace CalorieWise.Api.Features.Account.Login.V1
{
    internal interface IAccountLoginService
    {
        string VerifyAndGenerateJWTToken(AccountLoginRequest request);
    }
}