using System;
using System.Diagnostics.Contracts;

public class Square : Shape
{
    private double _side;


    public Square(string color, double s) : base(color)
    {
        _side = s;

    }


    public override double GetArea()
    {
        return _side * _side;
    }
}