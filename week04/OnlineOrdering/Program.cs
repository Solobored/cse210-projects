using System;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("Provo Peaks", "Provo", "UT", "USA");
        Address canadaAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Josue Neicuelo", usaAddress);
        Customer customer2 = new Customer("Javiera Fernandez", canadaAddress);

        Product product1 = new Product("Laptop", 101, 999.99, 1);
        Product product2 = new Product("Mouse", 102, 25.50, 2);
        Product product3 = new Product("Keyboard", 103, 45.75, 1);
        Product product4 = new Product("Monitor", 104, 150.00, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(new Product("Webcam", 105, 70.00, 1));

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}\n");
        Console.WriteLine(new string('-', 40) + "\n");
    }
}