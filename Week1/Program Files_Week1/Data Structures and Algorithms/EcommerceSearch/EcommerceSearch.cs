using System;

public class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

public class EcommerceSearch
{
    public static Product? LinearSearch(Product[] products, int id)
    {
        foreach (var product in products)
        {
            if (product.ProductId == id)
                return product;
        }
        return null;
    }

    public static Product? BinarySearch(Product[] products, int id)
    {
        int low = 0, high = products.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (products[mid].ProductId == id) return products[mid];
            if (products[mid].ProductId < id) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }

    public static void Main(string[] args)
    {
        Product[] products = {
            new Product(305, "Coffee Maker", "Home"),
            new Product(203, "Shirt", "Apparel"),
            new Product(101, "Laptop", "Electronics"),
            new Product(401, "Book", "Stationery")
        };

        Array.Sort(products, (a, b) => a.ProductId.CompareTo(b.ProductId));

        Console.Write("Enter Product ID to search: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int searchId))
        {
            Console.WriteLine("❌ Invalid Product ID.");
            return;
        }

        Product? result1 = LinearSearch(products, searchId);
        Console.WriteLine("\n[Linear Search Result]");
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found.");

        Product? result2 = BinarySearch(products, searchId);
        Console.WriteLine("\n[Binary Search Result]");
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found.");
    }
}
