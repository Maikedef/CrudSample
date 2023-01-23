using CrudSample.Domain.Entities.Empresas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CrudSample.Infrastructure.Data.Mapping.Empresas
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresa");

            builder.HasKey(prop => prop.Id).HasName("id");

            builder.Property(prop => prop.Nome)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .HasColumnName("nome");

            builder.Property(prop => prop.Cnpj)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .HasColumnName("cnpj");

            builder.Property(prop => prop.Telefone)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .HasColumnName("telefone");

            builder.Property(prop => prop.CriadoEm)
                .HasColumnName("criado_em");

            builder.Property(prop => prop.AtualizadoEm)
                .HasColumnName("atualizado_em");

            builder.Property(prop => prop.EnderecoId)
                .HasColumnName("endereco_id");
        }
    }
}
