using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    internal class JobCategoryEntityTypeConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            var seed = GetJobCategoriesSeed();

            builder.HasData(seed);
        }

        private static List<JobCategory> GetJobCategoriesSeed()
        {
            var list = new List<JobCategory>
            {
                new()
                {
                    Id = 1,
                    Title = "Developer"
                },
                new()
                {
                    Id= 2,
                    Title = "Manager"
                },
                new()
                {
                    Id = 3,
                    Title = "Team leader"
                }
            };

            return list;
        }
    }
}
