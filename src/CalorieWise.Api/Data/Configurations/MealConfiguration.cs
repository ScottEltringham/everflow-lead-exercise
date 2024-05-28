using CalorieWise.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CalorieWise.Api.Data.Configurations
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(id => id.Value, value => new MealId(value))
                .UseIdentityColumn();

            builder.HasOne(a => a.Account)
                .WithMany(m => m.Meals)
                .HasForeignKey(k => k.AccountId);
        }
    }
}
