using System;
using System.Net.Http.Headers;
class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _bottom = 1;
        _top = wholeNumber;
    }
    public Fraction(int top, int bottom)
    {
        _bottom = bottom;
        _top = top;
    }

    public int GettTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string fractionString = $"{_top}/{_bottom}";
        return fractionString;
    }
    public double GetDecimalValue()
    {
        double t = _top;
        double b = _bottom;
        return t / b;
    }
}