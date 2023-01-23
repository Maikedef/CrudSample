using FluentMigrator;

namespace CrudSample.Infrastructure.Data.Migrations.Versoes
{
    [Migration(1, "Migração inicial")]
    public class Versao0000001 : Migration
    {
        public override void Down()
        {
            Delete.Table("usuario");
            Delete.Table("endereco");
            Delete.Table("empresa");
        }

        public override void Up()
        {
            var usuario = Create.Table("usuario");
            usuario.WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("nome").AsString(100).NotNullable()
                .WithColumn("senha").AsString(2000).NotNullable()
                .WithColumn("role").AsString(100).NotNullable();

            var endereco = Create.Table("endereco");
            endereco.WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("logradouro").AsString(150)
                .WithColumn("numero").AsString(10)
                .WithColumn("bairro").AsString(100)
                .WithColumn("cidade").AsString(100)
                .WithColumn("estado").AsString(100);

            var empresa = Create.Table("empresa");
            empresa.WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("nome").AsString(150).NotNullable()
                .WithColumn("cnpj").AsString(20).Unique()
                .WithColumn("telefone").AsString(15)
                .WithColumn("criado_em").AsDateTime().WithDefaultValue(DateTime.Now)
                .WithColumn("atualizado_em").AsDateTime()
                .WithColumn("endereco_id").AsInt32().ForeignKey("endereco","id");
        }
    }
}
