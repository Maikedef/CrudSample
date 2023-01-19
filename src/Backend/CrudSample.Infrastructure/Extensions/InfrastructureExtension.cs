using CrudSample.Domain.Repository.Usuarios;
using CrudSample.Domain.Repositorys.UoW;
using CrudSample.Infrastructure.Data;
using CrudSample.Infrastructure.Data.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

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
            string stringConexao = configuration.ObterStringConexaoCompleta();
            services.AddDbContext<CrudSampleDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
            });
            services.AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUnityOfWork, UnityOfWork>();
            
        }
    }
}
