using CalorieWise.Api.Data;
using CalorieWise.Api.Features.Meal.Create.V1;
using CalorieWise.Api.UnitTest.Fakes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieWise.Api.UnitTest.Features.Meal.Create.V1
{
    [TestClass]
    public class MealCreateServiceTests
    {
        private FakeCreateRepository<Data.Models.Meal, CalorieWiseDbContext> _fakeCreateRepository;
        private MealCreateService _mealCreateService;

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeCreateRepository = new FakeCreateRepository<Data.Models.Meal, CalorieWiseDbContext>();
            _mealCreateService = new MealCreateService(_fakeCreateRepository);
        }

        [TestMethod]
        public async Task CreateNewMeal_ShouldReturnTrue_WhenMealIsAdded()
        {
            var newMeal = new Data.Models.Meal
            {
                MealName = "Test",
                MealDescription = "Test",
                Calories = 600,
                MealDate = DateOnly.FromDateTime(DateTime.UtcNow)
            };

            var result = await _mealCreateService.CreateNewMeal(newMeal);

            result.Should().BeTrue();
            _fakeCreateRepository.Entities.Should().HaveCount(1);
            _fakeCreateRepository.Entities[0].MealName.Should().Be("Test");
        }
    }
}