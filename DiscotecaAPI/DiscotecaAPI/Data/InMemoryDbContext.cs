using DiscotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscotecaAPI.Data
{
    public class InMemoryDbContext : DbContext
    {
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comanda> Comandas { get; set; }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options)
        {
        }
    }
}
