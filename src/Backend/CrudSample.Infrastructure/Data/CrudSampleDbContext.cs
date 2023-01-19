using CrudSample.Domain.Entities.Empresas;
using CrudSample.Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
