using Microsoft.EntityFrameworkCore;
using UCDBProdutos.Business.Models;

namespace UCDBProdutos.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}
