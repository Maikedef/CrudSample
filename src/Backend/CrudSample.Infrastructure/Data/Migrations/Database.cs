using Dapper;
using MySql.Data.MySqlClient;

namespace CrudSample.Infrastructure.Data.Migrations
{
    public static class Database
    {
        public static void CriarDatabase(string stringConexao, string nomeDatabase)
        {
            using var conexao = new MySqlConnection(stringConexao);
            conexao.Open();

            var parametros = new DynamicParameters();
            parametros.Add("nomeDatabase", nomeDatabase);

            conexao.Execute($"CREATE DATABASE IF NOT EXISTS {nomeDatabase}");
        }
    }
}
