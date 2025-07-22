using System;

class Program
{
    static void Main(string[] args)
    {
        // First customer and order (USA)
        Address address1 = new Address("123 Apple St", "Provo", "UT", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P010", 1.50, 5));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));

        // Second customer and order (International)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emily Davis", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N200", 5.75, 3));
        order2.AddProduct(new Product("Markers", "M333", 3.25, 4));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
