using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Account.Login.V1;
using CalorieWise.Api.UnitTest.Fakes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieWise.Api.UnitTest.Features.Account.Login.V1
{
    [TestClass]
    public class AccountLoginServiceTests
    {
        private FakeJWTTokenGenerator _fakeJWTTokenGenerator;
        private FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext> _fakeReadRepository;
        private AccountLoginService _accountLoginService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeJWTTokenGenerator = new FakeJWTTokenGenerator();
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([]);
            _accountLoginService = new AccountLoginService(_fakeJWTTokenGenerator, _fakeReadRepository);
        }

        [TestMethod]
        public void VerifyAndGenerateJWTToken_ShouldReturnEmptyString_IfCredentialsAreInvalid()
        {
            var request = new AccountLoginRequest { Username = "testuser", Password = "wrongpassword" };

            var result = _accountLoginService.VerifyAndGenerateJWTToken(request);

            result.Should().BeEmpty();
        }

        [TestMethod]
        public void VerifyAndGenerateJWTToken_ShouldReturnJWTToken_IfCredentialsAreValid()
        {
            var account = new Data.Models.Account { Username = "testuser", Password = PasswordHelper.HashPassword("correctpassword") };
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([account]);
            _accountLoginService = new AccountLoginService(_fakeJWTTokenGenerator, _fakeReadRepository);

            var request = new AccountLoginRequest { Username = "testuser", Password = "correctpassword" };

            var result = _accountLoginService.VerifyAndGenerateJWTToken(request);

            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void CredentialsAreValid_ShouldReturnFalse_IfUserDoesNotExist()
        {
            // Arrange
            var request = new AccountLoginRequest { Username = "nonexistentuser", Password = "any_password" };

            // Act
            var result = _accountLoginService.CredentialsAreValid(request);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void CredentialsAreValid_ShouldReturnFalse_IfPasswordIsIncorrect()
        {
            // Arrange
            var account = new Data.Models.Account { Username = "testuser", Password = PasswordHelper.HashPassword("correctpassword") };
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([account]);
            _accountLoginService = new AccountLoginService(_fakeJWTTokenGenerator, _fakeReadRepository);

            var request = new AccountLoginRequest { Username = "testuser", Password = "wrongpassword" };

            // Act
            var result = _accountLoginService.CredentialsAreValid(request);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void CredentialsAreValid_ShouldReturnTrue_IfCredentialsAreCorrect()
        {
            // Arrange
            var account = new Data.Models.Account { Username = "testuser", Password = PasswordHelper.HashPassword("correctpassword") };
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([account]);
            _accountLoginService = new AccountLoginService(_fakeJWTTokenGenerator, _fakeReadRepository);

            var request = new AccountLoginRequest { Username = "testuser", Password = "correctpassword" };

            // Act
            var result = _accountLoginService.CredentialsAreValid(request);

            // Assert
            result.Should().BeTrue();
        }
    }
}