using Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            const string connectionStringName = "DefaultConnection";

            var connectionString = configuration.GetConnectionString(connectionStringName);

            services.AddDbContext<AppDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    sqlServerOptions.MigrationsAssembly(nameof(Persistence));
                });
            });

            services.AddScoped<IDbContext, AppDbContext>();

            return services;
        }
    }
}
