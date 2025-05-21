using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment m = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        WritingAssignment w = new WritingAssignment("Mary Waters", "European History", "The Causes od World War II");
        Console.WriteLine(a.GetSummary());
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());

    }
}