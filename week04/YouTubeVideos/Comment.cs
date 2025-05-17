using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Transactions;

public class Comment
{
    private string _personName;
    private string _text;

    public Comment(string name, string text)
    {
        _personName = name;
        _text = text;
    }
    public void Display()
    {
        Console.WriteLine($"Name of Person: {_personName}");
        Console.WriteLine($"Text: {_text}");
    }
}