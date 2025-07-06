using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // must exactly match your LocalDB instance name
            options.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  Database=RetailInventoryDb;
                  Trusted_Connection=True;"
            );
        }
    }
}
