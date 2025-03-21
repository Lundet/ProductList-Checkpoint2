using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public string Category { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string category, string name, decimal price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}

public class Program
{
    public static void Main()
    {
        List<Product> products = new List<Product>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("To enter a product 'p', To search for a product enter 's', To quit enter 'q'");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------");
            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine().ToLower();

            // Using if-else to handle choices
            if (input == "p") // Add product
            {
                try
                {
                    Console.Write("Enter a Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter a Category: ");
                    string category = Console.ReadLine();

                    Console.Write("Enter a Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    products.Add(new Product(category, name, price));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe product was successfully added.");
                    Console.ResetColor();
                    Console.WriteLine("--------------------------------------------------");

                    // Using LINQ to sort products by price (Low to High) and calculate the total
                    var sortedProducts = products.OrderBy(p => p.Price);

                    // Display the sorted product list (Low to High by Price)
                    Console.WriteLine("\nUpdated Product List:");
                    decimal total = sortedProducts.Sum(p => p.Price); // LINQ to calculate total
                    foreach (var product in sortedProducts)
                    {
                        Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}");
                    }
                    Console.WriteLine($"\nTotal Price: {total}");
                    Console.WriteLine("--------------------------------------------------");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid price input, please enter a valid number.");
                }
            }
            else if (input == "s") // Search product
            {
                Console.Write("Enter product name to search: ");
                string searchQuery = Console.ReadLine();

                // Using LINQ to search products by name 
                var searchResults = products.Where(p => p.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

                if (searchResults.Any())
                {
                    Console.WriteLine("\nSearch Results:");
                    foreach (var product in searchResults)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("\nNo products found matching the search.");
                }

                Console.WriteLine("--------------------------------------------------");
            }
            else if (input == "q") // Quit
            {
                running = false;
            }
            else // Invalid input
            {
                Console.WriteLine("\nInvalid input. Please try again.");
            }
        }

        // After quitting, display the final sorted product list (Low to High by Price) and calculate total
        var finalSortedProducts = products.OrderBy(p => p.Price).ToList();
        Console.WriteLine("\nFinal Product List:");
        decimal finalTotal = finalSortedProducts.Sum(p => p.Price); // Using LINQ to calculate total
        foreach (var product in finalSortedProducts)
        {
            Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}");
        }
        Console.WriteLine($"\nFinal Total Price: {finalTotal}");
    }
}
