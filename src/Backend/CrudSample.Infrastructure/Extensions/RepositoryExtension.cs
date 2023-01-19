using Microsoft.Extensions.Configuration;

namespace CrudSample.Infrastructure.Extensions
{
    public static class RepositoryExtension
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
    }
}
