using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1) Create your DbContext
            using var ctx = new AppDbContext();

            // ─── LAB 4: Ensure & Seed ───────────────────────────

            // Ensure the database and tables exist
            await ctx.Database.EnsureCreatedAsync();

            // Only seed if there are no categories yet
            if (!ctx.Categories.Any())
            {
                // Create two categories
                var electronics = new Category { Name = "Electronics" };
                var groceries   = new Category { Name = "Groceries"   };

                await ctx.Categories.AddRangeAsync(electronics, groceries);

                // Create two products, linking to those categories
                var laptop  = new Product { Name = "Laptop",   Price = 75000m, Category = electronics };
                var riceBag = new Product { Name = "Rice Bag", Price = 1200m,  Category = groceries };

                await ctx.Products.AddRangeAsync(laptop, riceBag);
                await ctx.SaveChangesAsync();

                Console.WriteLine("Seed data inserted.");
            }

            // ─── LAB 5: Query & Display ─────────────────────────

            // A) List all products with their category
            var allProducts = await ctx.Products
                .Include(p => p.Category)
                .ToListAsync();

            Console.WriteLine("\n--- All Products ---");
            allProducts.ForEach(p =>
                Console.WriteLine($"• {p.Name} ({p.Category.Name}): ₹{p.Price}")
            );

            // B) Find a product by primary key (Id = 1)
            var first = await ctx.Products.FindAsync(1);
            Console.WriteLine($"\nFound by PK: {first?.Name} @ ₹{first?.Price}");

            // C) Get any product over ₹50,000
            var expensive = await ctx.Products
                .FirstOrDefaultAsync(p => p.Price > 50_000m);
            Console.WriteLine($"Most expensive: {expensive?.Name}");
        }
    }
}
