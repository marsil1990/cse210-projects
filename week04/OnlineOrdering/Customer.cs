using System;
using System.Runtime.CompilerServices;

public class Customer
{
    private string _name;
    private Adress _adress;

    public Customer(string name, Adress adress)
    {
        _adress = adress;
        _name = name;
    }
    public bool LiveInUSA()
    {
        return _adress.LiveInUSA();

    }

    public string GetName()
    {
        return _name;
    }

    public Adress GetAdress()
    {
        return _adress;
    }
}