using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square("Green", 4);
        Circle c = new Circle("Red", 5);
        Rectangle r = new Rectangle("Black", 2, 3);
        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(c);
        shapes.Add(r);


        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} - Area: {shape.GetArea():F2}");
        }
    }
}