using CrudSample.Domain.Entities.Empresas;
using CrudSample.Domain.Entities.Usuarios;
using CrudSample.Infrastructure.Data.Mapping.Empresas;
using CrudSample.Infrastructure.Data.Mapping.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace CrudSample.Infrastructure.Data
{
    public class CrudSampleDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public CrudSampleDbContext(DbContextOptions<CrudSampleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudSampleDbContext).Assembly);

            modelBuilder.Entity<Usuario>(new UsuarioMapping().Configure);
            modelBuilder.Entity<Empresa>(new EmpresaMapping().Configure);
        }
    }
}
