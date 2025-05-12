using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f = new Fraction();
        Fraction f1 = new Fraction(10);
        Fraction f2 = new Fraction(3, 4);

        Console.WriteLine($"fraction: {f.GetFractionString()}, Decimal: {f.GetDecimalValue()}");
        Console.WriteLine($"fraction: {f1.GetFractionString()}, Decimal: {f1.GetDecimalValue()}");
        Console.WriteLine($"fraction: {f2.GetFractionString()}, Decimal: {f2.GetDecimalValue()}");

        f2.SetTop(5);
        f2.SetBottom(10);

        Console.WriteLine($"f2 top change to {f2.GettTop()} and bottom change to {f2.GetBottom()}");
        Console.WriteLine($"fraction: {f2.GetFractionString()}, Decimal: {f2.GetDecimalValue()}");


    }
}