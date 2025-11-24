using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Create Addresses
        Address usaAddress = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Address internationalAddress = new Address("50 Rue de Rivoli", "Paris", "Ile-de-France", "France");

        // 2. Create Customers
        Customer usaCustomer = new Customer("John Smith", usaAddress);
        Customer intlCustomer = new Customer("Marie Dupont", internationalAddress);

        // 3. Create Products
        Product p1 = new Product("Smart Watch X", "SW10", 89.99m, 1);
        Product p2 = new Product("Charging Cable Pro", "CC5", 15.50m, 2);
        Product p3 = new Product("Travel Adapter", "TA2", 25.00m, 3);
        Product p4 = new Product("Bluetooth Headphones", "BH20", 49.95m, 1);
        
        // 4. Create Order 1 (USA - Shipping $5)
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // 5. Create Order 2 (International - Shipping $35)
        Order order2 = new Order(intlCustomer);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p2); // Reusing a product

        // --- DISPLAYING RESULTS ---
        
        DisplayOrderDetails(order1, "ORDER 1 (USA)");
        DisplayOrderDetails(order2, "ORDER 2 (INTERNATIONAL)");
    }

    // Helper method to display the details of an order
    public static void DisplayOrderDetails(Order order, string header)
    {
        Console.WriteLine("======================================");
        Console.WriteLine($"*** {header} ***");
        Console.WriteLine("======================================");

        // Display Shipping Label
        Console.WriteLine("\n--- Shipping Label ---");
        Console.WriteLine(order.GetShippingLabel());

        // Display Packing Label
        Console.WriteLine("\n--- Packing Label ---");
        Console.Write(order.GetPackingLabel());

        // Display Total Cost
        decimal totalCost = order.CalculateTotalCost();
        
        // Determine the shipping cost to display separately
        decimal shippingCost = order.Customer.IsInUSA() ? 5.00m : 35.00m;
        
        Console.WriteLine("\n--- Billing Details ---");
        Console.WriteLine($"Shipping Cost: ${shippingCost:F2}");
        Console.WriteLine($"Order Total (Including Shipping): **${totalCost:F2}**");
        Console.WriteLine("--------------------------------------\n");
    }
}