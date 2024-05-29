using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Account.Create.V1;
using CalorieWise.Api.UnitTest.Fakes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieWise.Api.UnitTest.Features.Account.Create.V1
{

    [TestClass]
    public class AccountCreateServiceTests
    {
        private FakeCreateRepository<Data.Models.Account, CalorieWiseDbContext> _fakeCreateRepository;
        private FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext> _fakeReadRepository;
        private AccountCreateService _accountCreateService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeCreateRepository = new FakeCreateRepository<Data.Models.Account, CalorieWiseDbContext>();
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([]);
            _accountCreateService = new AccountCreateService(_fakeCreateRepository, _fakeReadRepository);
        }

        [TestMethod]
        public async Task CreateNewAccount_ShouldReturnFalse_IfUserNameIsTaken()
        {
            var existingAccount = new Data.Models.Account { Username = "testuser" };
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([existingAccount]);
            _accountCreateService = new AccountCreateService(_fakeCreateRepository, _fakeReadRepository);

            var newAccount = new Data.Models.Account { Username = "testuser" };

            var result = await _accountCreateService.CreateNewAccount(newAccount);

            result.Should().BeFalse();
            _fakeCreateRepository.Entities.Should().BeEmpty();
        }

        [TestMethod]
        public async Task CreateNewAccount_ShouldReturnTrue_AndCallAddAsync_IfUserNameIsNotTaken()
        {
            var newAccount = new Data.Models.Account { Username = "newuser" };

            var result = await _accountCreateService.CreateNewAccount(newAccount);

            result.Should().BeTrue();
            _fakeCreateRepository.Entities.Should().ContainSingle(a => a.Username == "newuser");
        }

        [TestMethod]
        public void UserNameIsTaken_ShouldReturnTrue_IfUserNameExists()
        {
            var existingAccount = new Data.Models.Account { Username = "testuser" };
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([existingAccount]);
            _accountCreateService = new AccountCreateService(_fakeCreateRepository, _fakeReadRepository);

            var result = _accountCreateService.UserNameIsTaken("testuser");

            result.Should().BeTrue();
        }

        [TestMethod]
        public void UserNameIsTaken_ShouldReturnFalse_IfUserNameDoesNotExist()
        {
            // Arrange
            _fakeReadRepository = new FakeReadRepository<Data.Models.Account, Data.Models.AccountId, CalorieWiseDbContext>([]);
            _accountCreateService = new AccountCreateService(_fakeCreateRepository, _fakeReadRepository);

            // Act
            var result = _accountCreateService.UserNameIsTaken("nonexistentuser");

            // Assert
            result.Should().BeFalse();
        }
    }
}