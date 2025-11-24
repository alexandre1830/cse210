using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>(); // Composition: Order has a list of Products
    private Customer _customer;                           // Composition: Order has a Customer

    public Order(Customer customer)
    {
        _customer = customer;
    }

    // Accessor Property (Getter)
    public Customer Customer
    {
        get { return _customer; }
    }

    // Helper method to add products
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order, including shipping
    public decimal CalculateTotalCost()
    {
        decimal productsTotal = 0;

        // 1. Sums the total cost of all products
        foreach (Product product in _products)
        {
            productsTotal += product.GetTotalCost();
        }

        // 2. Determines the shipping cost
        // $5 for USA, $35 for International
        decimal shippingCost = _customer.IsInUSA() ? 5.00m : 35.00m;

        // 3. Returns the grand total
        return productsTotal + shippingCost;
    }

    // Method to generate the Packing Label
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Packing Label ---");
        
        foreach (Product product in _products)
        {
            label.AppendLine($"ID: {product.ProductId} | Name: {product.Name}");
        }
        return label.ToString();
    }

    // Method to generate the Shipping Label
    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Shipping Label ---");
        // Customer name
        label.AppendLine($"Customer: {_customer.Name}");
        // Full address (uses the GetFullAddress method from Address)
        label.AppendLine(_customer.Address.GetFullAddress());
        
        return label.ToString();
    }
}