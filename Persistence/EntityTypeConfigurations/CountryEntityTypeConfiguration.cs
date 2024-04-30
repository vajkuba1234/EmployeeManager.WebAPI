using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    internal class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            var seed = GetCountriesSeed();

            builder.HasData(seed);
        }

        private static List<Country> GetCountriesSeed()
        {
            var list = new List<Country>
            {
                new() {
                    Id = 1,
                    Name = "CZ"
                },
                new() {
                    Id= 2,
                    Name = "SK"
                }
            };

            return list;
        }
    }
}
