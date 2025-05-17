using System;
using System.Runtime.CompilerServices;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }
    public double TotalCost()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total = total + p.TotalCost();
        }
        if (_customer.LiveInUSA())
        {
            total = total + 5;
        }
        else
        {
            total = total + 35;
        }
        return total;
    }
    public string PackingLabel()
    {
        string label = "Packing label:\n";
        foreach (Product p in _products)
        {
            label = label + $"-{p.GetName()} (ID: {p.GetPorductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        string label = $"Name: {_customer.GetName()},\n Adress: {_customer.GetAdress().Display()}";
        return label;
    }
}
