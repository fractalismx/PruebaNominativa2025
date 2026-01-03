using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class RelationalDbContext : DbContext
    {
        public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Database.ProviderName == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                modelBuilder.Entity<Cliente>(e =>
                {
                    e.ToTable("clientes", "public");    
                    e.Property(x => x.Id).HasColumnName("id");
                    e.Property(x => x.Nombre).HasColumnName("nombre");
                });
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
