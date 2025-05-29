using System;
using System.Diagnostics.Contracts;
using System.Drawing;

public abstract class Shape
{
    private string _color;

    public Shape(string c)
    {
        _color = c;
    }
    public string GetColor()
    {
        return _color;
    }
    public void SetColor(string c)
    {
        _color = c;
    }

    public abstract double GetArea();
}