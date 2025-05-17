using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Online Ordering System!\n");
        Adress adress1 = new Adress("123 Main St", "New York", "NY", "USA");
        Adress adress2 = new Adress("456 Oxford St", "London", "England", "UK");

        Customer c1 = new Customer("Alice Johnson", adress1);
        Customer c2 = new Customer("Bob", adress2);

        Order o1 = new Order(c1);
        Order o2 = new Order(c2);

        Product p1 = new Product("Laptop", "P1001", 1, 1200.0);
        Product p2 = new Product("Mouse", "P1002", 2, 25.0);

        o1.AddProduct(p1);
        o1.AddProduct(p2);

        Product p3 = new Product("Smartphone", "P2001", 1, 800.0);
        Product p4 = new Product("Headphone", "P2002", 1, 150.0);
        Product p5 = new Product("Charger", "P2003", 2, 20.0);
        o2.AddProduct(p3);
        o2.AddProduct(p4);
        o2.AddProduct(p5);

        Console.WriteLine("Order 1: ");
        Console.WriteLine(o1.PackingLabel());
        Console.WriteLine(o1.ShippingLabel());
        Console.WriteLine($"Total price: {o1.TotalCost():f2}\n");

        Console.WriteLine("Order 2: ");
        Console.WriteLine(o2.PackingLabel());
        Console.WriteLine(o2.ShippingLabel());
        Console.WriteLine($"Total price: {o2.TotalCost():f2}\n");


    }
}