using Microsoft.EntityFrameworkCore;

namespace DemoWsEF1.Models
{
    public class BdContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public BdContext()
        {   
        }
        public BdContext (DbContextOptions<BdContext> options)
            : base(options)
        {
        }
    }
}