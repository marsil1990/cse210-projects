using System;
using System.Diagnostics.Contracts;

public class Circle : Shape
{
    private double _radius;


    public Circle(string color, double r) : base(color)
    {
        _radius = r;

    }


    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}