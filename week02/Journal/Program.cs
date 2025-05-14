using System;
/*I enhanced the journal application by adding functionality to save and load
 entries using a SQLite database. To implement this feature, I first installed the required SQlite library 
 using dotnet add package System.Data.SQLite
 Then, I created methods to handle database interactions in Journal.cs */
class Program
{
    static void Main(string[] args)
    {
        Journal j = new Journal();
        PromptGenerator p = new PromptGenerator();
        p._prompts.Add("Who was the most interesting person I interacted with today?");
        p._prompts.Add("What was the best part of my day?");
        p._prompts.Add("How did I see the hand of the Lord in my life today?");
        p._prompts.Add("What was the strongest emotion I felt today?");
        p._prompts.Add("If I had one thing I could do over today, what would it be?");

        p._prompts.Add("What did I learn about myself today?");
        p._prompts.Add("What am I grateful for today?");
        p._prompts.Add("What is one thing I can improve tomorrow?");
        int option = -1;
        while (option != 7)
        {
            Console.WriteLine("Plase select one of the follwing choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Save to Database");
            Console.WriteLine("6. Load from Database");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                string prompt = p.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string entry = Console.ReadLine();
                Entry e = new Entry();
                e._date = dateText;
                e._entryText = entry;
                e._promptText = prompt;
                j.AddEntry(e);
            }
            else if (option == 2)
            {
                j.Display();
            }
            else if (option == 3)
            {
                Console.WriteLine("What is the filename? ");
                string fileName = Console.ReadLine();
                j.loadFromFile(fileName);
            }
            else if (option == 4)
            {
                Console.WriteLine("What is the filename? ");
                string fileName = Console.ReadLine();
                j.SaveToFile(fileName);
            }
            else if (option == 5)
            {
                Console.WriteLine("Enter database file name (e.g., journal.db): ");
                string dbFile = Console.ReadLine();
                string connectionString = $"Data Source ={dbFile}; Version=3;";
                j.SaveToDatabase(connectionString);
            }
            else if (option == 6)
            {
                Console.WriteLine("Enter database file name (e.g., journal.txt): ");
                string dbFile = Console.ReadLine();
                string connectionString = $"Data Source={dbFile}; Version=3;";
                j.LoadFromDatabase(connectionString);
            }

        }
    }
}