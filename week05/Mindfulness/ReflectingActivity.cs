using System;
using System.Diagnostics.Contracts;
using System.Dynamic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    private List<int> _usedQuestionIndex;

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");

        _usedQuestionIndex = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
    }

    public string GetRandomPrompt()
    {
        Random r = new Random();
        string prompt = _prompts[r.Next(0, _prompts.Count())];
        return $"--- {prompt}. ---";
    }
    public string GetRandomQuestions()
    {
        Random r = new Random();
        if (_usedQuestionIndex.Count() > 0)
        {
            int randomIndex = r.Next(0, _usedQuestionIndex.Count());
            int index = _usedQuestionIndex[randomIndex];
            string question = _questions[index];
            _usedQuestionIndex.Remove(index);
            return question;
        }
        else
        {
            return "There are no more questions";
        }
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestions());
    }

    public void Run()
    {
        DispaleyStartingMessage();
        setDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"{GetRandomPrompt()}\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < futureTime && _usedQuestionIndex.Count() > 0)
        {
            Console.Write($"> {GetRandomQuestions()} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
        SaveToFile();
        DispaleyEndingMessage();
    }

}