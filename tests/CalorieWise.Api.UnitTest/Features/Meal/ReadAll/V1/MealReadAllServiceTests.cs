using CalorieWise.Api.Data.Models;
using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Meal.ReadAll.V1;
using CalorieWise.Api.UnitTest.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace CalorieWise.Api.UnitTest.Features.Meal.ReadAll.V1
{
    [TestClass]
    public class MealReadAllServiceTests
    {
        private List<Data.Models.Meal> _meals;
        private FakeReadRepository<Data.Models.Meal, MealId, CalorieWiseDbContext> _fakeReadRepository;
        private MealReadAllService _mealReadAllService;

        [TestInitialize]
        public void TestInitialize()
        {
            _meals =
            [
                new() { Id = new MealId(1L), AccountId = new AccountId(1L), MealName = "Meal 1" },
                new() { Id = new MealId(2L), AccountId = new AccountId(1L), MealName = "Meal 2" }
            ];
            _fakeReadRepository = new FakeReadRepository<Data.Models.Meal, MealId, CalorieWiseDbContext>(_meals);
            _mealReadAllService = new MealReadAllService(_fakeReadRepository);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnMeals_WhenMealsExistForAccount()
        {
            var request = new MealReadAllRequest { AccountId = 1L };

            var result = await _mealReadAllService.GetAllAsync(request);

            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }

        [TestMethod]
        public async Task GetAllAsync_ShouldReturnEmpty_WhenMealsDoNotExistForAccount()
        {
            var request = new MealReadAllRequest { AccountId = 2L };

            var result = await _mealReadAllService.GetAllAsync(request);

            result.Should().NotBeNull();
            result.Should().HaveCount(0);
        }
    }   
}