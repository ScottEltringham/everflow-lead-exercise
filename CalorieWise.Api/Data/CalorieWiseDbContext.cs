using CalorieWise.Api.Data.Configurations;
using CalorieWise.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CalorieWise.Api.Data
{
    public class CalorieWiseDbContext(DbContextOptions<CalorieWiseDbContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
