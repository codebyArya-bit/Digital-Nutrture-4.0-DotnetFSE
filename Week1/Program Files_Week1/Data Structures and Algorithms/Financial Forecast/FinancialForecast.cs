using System;

public class FinancialForecast
{
    // Recursive forecast method
    public static double ForecastRecursive(double value, double rate, int years)
    {
        if (years == 0) return value;
        return ForecastRecursive(value * (1 + rate), rate, years - 1);
    }

    // Iterative forecast method
    public static double ForecastIterative(double value, double rate, int years)
    {
        for (int i = 0; i < years; i++)
        {
            value *= (1 + rate);
        }
        return value;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter initial amount (₹): ");
        string? inputAmount = Console.ReadLine();
        Console.Write("Enter growth rate (in %, e.g., 10 for 10%): ");
        string? inputRate = Console.ReadLine();
        Console.Write("Enter number of years: ");
        string? inputYears = Console.ReadLine();

        // Null and format checks
        if (!double.TryParse(inputAmount, out double initial) ||
            !double.TryParse(inputRate, out double ratePercent) ||
            !int.TryParse(inputYears, out int years))
        {
            Console.WriteLine("Invalid input. Please enter numeric values.");
            return;
        }

        double rate = ratePercent / 100.0;

        double rec = ForecastRecursive(initial, rate, years);
        double iter = ForecastIterative(initial, rate, years);

        Console.WriteLine($"Recursive Forecast: ₹{rec:F2}");
        Console.WriteLine($"Iterative Forecast: ₹{iter:F2}");
    }
}
