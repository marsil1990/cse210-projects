using System;
using System.Threading.Tasks.Dataflow;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(string name, string description) : base(name, description)
    {
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public string GetRandomPrompt()
    {
        Random r = new Random();
        return _prompts[r.Next(0, _prompts.Count())];
    }

    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < futureTime)
        {
            Console.Write("> ");
            string newItem = Console.ReadLine();
            userList.Add(newItem);
            _count++;
        }
        Console.WriteLine($"\nYour Listed {_count} items!");
        return userList;
    }

    public void Run()
    {
        DispaleyStartingMessage();
        setDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine("\nList as many responses you can to the following prompt: ");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        List<string> userList = GetListFromUser();
        SaveToFile();
        DispaleyEndingMessage();
    }
}