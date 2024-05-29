using CalorieWise.Api.Data.Models;
using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Meal.Delete.V1;
using CalorieWise.Api.UnitTest.Fakes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieWise.Api.UnitTest.Features.Meal.Delete.V1
{
    [TestClass]
    public class MealDeleteServiceTests
    {
        private List<Data.Models.Meal> _meals;
        private FakeDeleteRepository<Data.Models.Meal, MealId, CalorieWiseDbContext> _fakeDeleteRepository;
        private MealDeleteService _mealDeleteService;

        [TestInitialize]
        public void Setup()
        {
            _meals =
            [
                new() { Id = new MealId(1L), MealName = "Test Meal" }
            ];
            _fakeDeleteRepository = new FakeDeleteRepository<Data.Models.Meal, MealId, CalorieWiseDbContext>(_meals);
            _mealDeleteService = new MealDeleteService(_fakeDeleteRepository);
        }

        [TestMethod]
        public async Task DeleteMealAsync_ShouldRemoveMeal_WhenMealExists()
        {
            var request = new MealDeleteRequest { MealId = 1L };

            await _mealDeleteService.DeleteMealAsync(request);

            _meals.Should().BeEmpty();
        }
    }
}
