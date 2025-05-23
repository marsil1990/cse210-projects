using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _duration = 0;
        _description = description;
    }

    public void DispaleyStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"This activity will help you {_description}\n");

    }

    public void DispaleyEndingMessage()
    {
        Console.WriteLine($"\nWell done!!");
        ShowSpinner(5);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        int i = 0;
        List<string> spinnerList = new List<string>() { "|", "/", "-", "\\", "|", "/", "-", "\\" };
        while (DateTime.Now < futureTime)
        {
            Console.Write(spinnerList[i]);
            Thread.Sleep(200);
            Console.Write("\b \b"); // Erase the + character
            i++;
            if (i >= spinnerList.Count())
            {
                i = 0;
            }
        }

    }

    public void ShowCountDown(int seconds)
    {
        int i = seconds;
        while (i > 0)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
        }
        Console.WriteLine("");

    }
    public int GetDuration()
    {
        return _duration;
    }

    public void setDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        int seconds = int.Parse(Console.ReadLine());
        _duration = seconds;
    }

    public void SaveToFile()
    {
        string fileName = "log.txt";
        string fecha = DateTime.Now.ToString();
        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {


            outputFile.WriteLine($"> {fecha} - {_name} - {_description} - {_duration} seconds.");

        }
    }
}