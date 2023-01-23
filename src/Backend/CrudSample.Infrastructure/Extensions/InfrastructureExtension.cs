using CrudSample.Domain.Repositories.Empresas;
using CrudSample.Domain.Repositories.Usuarios;
using CrudSample.Domain.Repositories.UoW;
using CrudSample.Infrastructure.Data;
using CrudSample.Infrastructure.Data.Repositories.Empresas;
using CrudSample.Infrastructure.Data.Repositories.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudSample.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static string ObterStringConexao(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("StringConexao");
        }

        public static string ObterNomeDatabase(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("NomeDatabase");
        }

        public static string ObterStringConexaoCompleta(this IConfiguration configuration)
        {
            return $"{ObterStringConexao(configuration)}Database={ObterNomeDatabase(configuration)}";
        }

        public static void AddDependenciasInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            bool.TryParse(configuration.GetRequiredSection("Configuracoes:DbInMemory")?.Value, out bool dbInMemory);
            if (!dbInMemory)
            {
                string stringConexao = configuration.ObterStringConexaoCompleta();
                services.AddDbContext<CrudSampleDbContext>(dbContextOptions =>
                {
                    dbContextOptions.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                });
            }
        
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
