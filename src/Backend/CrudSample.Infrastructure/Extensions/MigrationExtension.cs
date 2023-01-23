using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrudSample.Infrastructure.Extensions
{
    public static class MigrationExtension
    {

        public static void AddFluentMigrator(this IServiceCollection services, IConfiguration configuration)
        {
            string conexaoString = configuration.ObterStringConexaoCompleta();
            services.AddFluentMigratorCore().ConfigureRunner(c =>
            {
                c.AddMySql5().WithGlobalConnectionString(conexaoString).ScanIn(Assembly.Load("CrudSample.Infrastructure")).For.All();
            });
        }
        public static void MigrateBancoDados(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();
            runner.MigrateUp();
        }
    }
}
