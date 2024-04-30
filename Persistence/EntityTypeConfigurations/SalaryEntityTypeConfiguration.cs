using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    internal class SalaryEntityTypeConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder
                .Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnType("money")
                .IsRequired();

            builder
                .Property(e => e.From)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(e => e.To)
                .HasColumnType("date")
                .IsRequired(false);
        }
    }
}
