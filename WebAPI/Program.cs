using Application.Extensions;
using Newtonsoft.Json.Linq;
using Persistence.Extensions;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services
                .AddApplication()
                .AddPersistence(configuration);

            builder.Services.AddCors(setup =>
            {
                setup.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                // Solves stack-overflow problem when generating api contracts for angular client using Nswag
                options.MapType<JObject>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "any" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyHeader();
                config.AllowAnyMethod();
                config.AllowAnyOrigin();
            });

            // Configure the HTTP request pipeline.
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api-docs/{documentName}.json";
                options.PreSerializeFilters.Add((swagger, httpRequest) =>
                {
                    swagger.Servers.Clear();
                });
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api-docs/v1.json", "v1");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
