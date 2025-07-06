using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailInventory.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;      // ← initialized

        // Navigation: one category → many products
        public List<Product> Products { get; set; } = new(); // ← initialized
    }
}
