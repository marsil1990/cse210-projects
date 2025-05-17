using System;
using System.Runtime.CompilerServices;

public class Product
{
    private string _name;
    private string _productId;
    private int _quantity;
    private double _pricePerUnit;

    public Product(string name, string id, int quantity, double pricePerUnit)
    {
        _name = name;
        _pricePerUnit = pricePerUnit;
        _productId = id;
        _quantity = quantity;
    }
    public double TotalCost()
    {
        double price = _pricePerUnit;
        return price * _quantity;
    }
    public string GetName()
    {
        return _name;
    }

    public string GetPorductId()
    {
        return _productId;
    }
}