using CrudSample.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrudSample.Test
{
    public class CrudSampleWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {
                    var descritor = services.SingleOrDefault(x => x.ServiceType == typeof(CrudSampleDbContext));
                    if(descritor != null)
                    {
                        services.Remove(descritor);
                    }

                    var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                    services.AddDbContext<CrudSampleDbContext>(option =>
                    {
                        option.UseInMemoryDatabase("InMemoryDbForTesting");
                        option.UseInternalServiceProvider(provider);
                    });

                    var serviceProvider = services.BuildServiceProvider();
                    using var scope = serviceProvider.CreateScope();
                    var scopeService = scope.ServiceProvider;
                    var database = scopeService.GetRequiredService<CrudSampleDbContext>();

                    database.Database.EnsureDeleted();

                    ContextSeedInMemory.Seed(database);
                });
        }
    }
}
