import java.util.*;

// Product class
class Product {
    int productId;
    String productName;
    String category;

    Product(int id, String name, String category) {
        this.productId = id;
        this.productName = name;
        this.category = category;
    }

    public String toString() {
        return "ID: " + productId + ", Name: " + productName + ", Category: " + category;
    }
}

public class EcommerceAndForecast {

    // =========================
    // Exercise 2: Search Logic
    // =========================
    public static Product linearSearch(Product[] products, int id) {
        for (Product p : products) {
            if (p.productId == id) return p;
        }
        return null;
    }

    public static Product binarySearch(Product[] products, int id) {
        int low = 0, high = products.length - 1;
        while (low <= high) {
            int mid = (low + high) / 2;
            if (products[mid].productId == id) return products[mid];
            if (products[mid].productId < id) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }

    // =========================
    // Exercise 7: Forecast Logic
    // =========================
    public static double forecastRecursive(double currentValue, double rate, int years) {
        if (years == 0) return currentValue;
        return forecastRecursive(currentValue * (1 + rate), rate, years - 1);
    }

    public static double forecastIterative(double currentValue, double rate, int years) {
        for (int i = 0; i < years; i++) {
            currentValue *= (1 + rate);
        }
        return currentValue;
    }

    // =========================
    // Main Program
    // =========================
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Setup product list
        Product[] products = {
            new Product(305, "Coffee Maker", "Home"),
            new Product(203, "Shirt", "Apparel"),
            new Product(101, "Laptop", "Electronics"),
            new Product(401, "Book", "Stationery"),
                new Product(5466, "Bluetooth Speaker", "Electronics")
        };

        // Sort for binary search
        Arrays.sort(products, (a, b) -> Integer.compare(a.productId, b.productId));

        System.out.println("======= E-COMMERCE SEARCH =======");
        System.out.print("Enter Product ID to search: ");
        int searchId = scanner.nextInt();

        Product foundLinear = linearSearch(products, searchId);
        Product foundBinary = binarySearch(products, searchId);

        System.out.println("\n[Linear Search Result]");
        System.out.println(foundLinear != null ? foundLinear : "Product not found.");

        System.out.println("[Binary Search Result]");
        System.out.println(foundBinary != null ? foundBinary : "Product not found.");

        System.out.println("\n======= FINANCIAL FORECAST =======");
        System.out.print("Enter initial amount (₹): ");
        double amount = scanner.nextDouble();

        System.out.print("Enter growth rate (as %, e.g., 10 for 10%): ");
        double rate = scanner.nextDouble() / 100;

        System.out.print("Enter number of years: ");
        int years = scanner.nextInt();

        double recursiveResult = forecastRecursive(amount, rate, years);
        double iterativeResult = forecastIterative(amount, rate, years);

        System.out.printf("\n[Recursive Forecast] =%.2f\n", recursiveResult);
        System.out.printf("[Iterative Forecast] =%.2f\n", iterativeResult);

        scanner.close();
    }
}
