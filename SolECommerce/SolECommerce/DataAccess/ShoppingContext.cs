using Microsoft.EntityFrameworkCore;
using SolECommerce.DataAccess.DBEntities;

namespace SolECommerce.DataAccess
{
    public class ShoppingContext : DbContext
    {
        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<OrderDetailEntity> OrderDetail { get; set; }

        public ShoppingContext(DbContextOptions<ShoppingContext> option) : base (option)
        {
        }
    }
}
