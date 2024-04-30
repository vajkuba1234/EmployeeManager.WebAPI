using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions
{
    public interface IDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        Task<bool> CommitAsync(CancellationToken cancellationToken = default);
    }
}
