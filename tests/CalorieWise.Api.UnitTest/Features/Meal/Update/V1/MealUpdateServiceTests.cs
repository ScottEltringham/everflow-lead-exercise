using CalorieWise.Api.Data.Models;
using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Meal.Update.V1;
using CalorieWise.Api.UnitTest.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace CalorieWise.Api.UnitTest.Features.Meal.Update.V1
{
    [TestClass]
    public class MealUpdateServiceTests
    {
        private List<Data.Models.Meal> _meals;
        private FakeReadRepository<Data.Models.Meal, MealId, CalorieWiseDbContext> _fakeReadRepository;
        private FakeUpdateRepository<Data.Models.Meal, MealId, CalorieWiseDbContext> _fakeUpdateRepository;
        private MealUpdateService _mealUpdateService;

        [TestInitialize]
        public void TestInitialize()
        {
            _meals =
            [
                new() { Id = new MealId(1L), MealName = "Original Name", Calories = 300 }
            ];
            _fakeReadRepository = new FakeReadRepository<Data.Models.Meal, MealId, CalorieWiseDbContext>(_meals);
            _fakeUpdateRepository = new FakeUpdateRepository<Data.Models.Meal, MealId, CalorieWiseDbContext>(_meals);
            _mealUpdateService = new MealUpdateService(_fakeReadRepository, _fakeUpdateRepository);
        }

        [TestMethod]
        public async Task UpdateMeal_ShouldReturnUpdatedMeal_WhenMealExists()
        {
            var request = new MealUpdateRequest
            {
                MealID = 1L,
                MealName = "Updated Name",
                Calories = 600
            };

            var result = await _mealUpdateService.UpdateMeal(request);

            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Name", result.MealName);
            Assert.AreEqual(600, result.Calories);
        }

        [TestMethod]
        public async Task UpdateMeal_ShouldReturnNull_WhenMealDoesNotExist()
        {
            var request = new MealUpdateRequest
            {
                MealID = 2L,
                MealName = "Updated Name",
                Calories = 600
            };

            var result = await _mealUpdateService.UpdateMeal(request);

            result.Should().BeNull();
        }
    }
}
