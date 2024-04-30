using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;

namespace Persistence
{
    internal class AppDbContext(DbContextOptions options) : DbContext(options), IDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            var saveResult = await SaveChangesAsync(cancellationToken);

            bool isSuccess = saveResult > 0;

            return isSuccess;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new JobCategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SalaryEntityTypeConfiguration());
        }
    }
}
