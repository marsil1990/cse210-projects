using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Transactions;

public class Video
{
    private string _title;
    private string _author;
    private double _lengthSecond;
    private List<Comment> _comments;


    public Video(string title, string author, double lenghtSecond)
    {
        _title = title;
        _author = author;
        _lengthSecond = lenghtSecond;
        _comments = new List<Comment>();
    }
    public int NumberOfComment()
    {
        return _comments.Count();
    }
    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Lenght: {_lengthSecond} seconds");
        Console.WriteLine($"Number of comments: {_comments.Count()}");
        foreach (Comment c in _comments)
        {
            Console.WriteLine("COMMENT: ");
            c.Display();

        }
        Console.WriteLine("===========================================================================================");
    }
    public void AddCommnet(Comment c)
    {
        _comments.Add(c);
    }
}
