using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    internal class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => e.BirthDate)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(e => e.JoinedDate)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(e => e.ExitedDate)
                .HasColumnType("date")
                .IsRequired(false);

            builder
                .HasOne(e => e.Superior)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SuperiorId)
                .IsRequired(false);

            builder
                .HasOne(e => e.Country)
                .WithMany()
                .HasForeignKey(e => e.CountryId)
                .IsRequired();

            builder
                .HasMany(e => e.JobCategories)
                .WithMany(e => e.Employees)
                .UsingEntity<EmployeeJobCategory>();
        }
    }
}
