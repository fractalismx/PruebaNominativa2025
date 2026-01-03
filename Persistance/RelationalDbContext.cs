using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class RelationalDbContext : DbContext
    {
        public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}
