using System.Data.SqlTypes;
using System.IO;
using System.Runtime.CompilerServices;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _lastEternalGoal;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string option = "0";
        while (option != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5  Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from menu: ");
            option = Console.ReadLine();
            if (option == "1")
            {
                CreateGoal();
            }
            else if (option == "2")
            {

                Console.WriteLine("The goals are: ");
                int index = 1;
                foreach (Goal g in _goals)
                {
                    if (g.IsComplete())
                    {
                        Console.Write($"{index}. [X] ");
                    }
                    else
                    {
                        Console.Write($"{index}. [ ] ");
                    }
                    if (g is CheckListGoal)
                    {
                        Console.WriteLine($"{g.GetName()} ({g.GetDescription()}) {g.getDetailsString()}");
                    }
                    else
                    {
                        Console.WriteLine($"{g.GetName()} ({g.GetDescription()})");
                    }

                    index++;

                }
            }
            else if (option == "3")
            {
                SaveGoals();


            }
            else if (option == "4")
            {
                LoadGoals();
            }
            else if (option == "5")
            {
                RecordEvent();

            }

        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        if (_lastEternalGoal == null || _lastEternalGoal == "")
        {
            Console.WriteLine("You haven't worked on an Eternal Goal\n");
        }
        else
        {
            DateTime date = DateTime.Today;
            Console.WriteLine($"The last time you worked on an Eternal Goal was {(date - DateTime.Parse(_lastEternalGoal)).Days} days ago\n");
        }
    }
    public void ListGoalNames()
    {
        int index = 1;
        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{index}. {g.GetName()}");
            index++;
        }
    }
    public void ListGoalDetails() { }
    public void CreateGoal()
    {
        Goal goal;
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalOption = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string nameGoal = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associates with this goal? ");
        int amountPoints = int.Parse(Console.ReadLine());
        if (goalOption == "1")
        {
            goal = new SimpleGoal(nameGoal, description, amountPoints);
            _goals.Add(goal);
        }
        else if (goalOption == "2")
        {
            goal = new EternalGoal(nameGoal, description, amountPoints);
            _goals.Add(goal);
        }
        else if (goalOption == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it many times? ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new CheckListGoal(nameGoal, description, amountPoints, target, bonus);
            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Incorrect option");
        }
    }
    public void RecordEvent()
    {
        ListGoalNames();
        Console.WriteLine("Which goal did you accomplish? ");
        int goalOption = int.Parse(Console.ReadLine());
        _goals[goalOption - 1].RecordEvent();
        if (_goals[goalOption - 1] is EternalGoal)
        {
            DateTime lastTime = DateTime.Today;
            _lastEternalGoal = lastTime.ToString();
        }
        Console.WriteLine($"Congratulations! You have earned {_goals[goalOption - 1].GetPoints()} points!");
        if (_goals[goalOption - 1].IsComplete() && _goals[goalOption - 1] is CheckListGoal)
        {
            _score += _goals[goalOption - 1].GetPoints() + _goals[goalOption - 1].GetBonus();
            Console.WriteLine("You earned a BONUS");
        }
        else if (_goals[goalOption - 1] is CheckListGoal)
        {
            _score += _goals[goalOption - 1].GetPoints();
        }
        else if (_goals[goalOption - 1].IsComplete())
        {
            _score += _goals[goalOption - 1].GetPoints();
        }
        else if (_goals[goalOption - 1] is EternalGoal)
        {
            _score += _goals[goalOption - 1].GetPoints();
        }

        Console.WriteLine($"You now have {_score} points");
    }
    public void SaveGoals()
    {
        Console.WriteLine("What is de filename for the goal file? ");
        string filenameSave = Console.ReadLine();
        using (StreamWriter outputfile = new StreamWriter(filenameSave))
        {
            outputfile.WriteLine(_score);
            outputfile.WriteLine(_lastEternalGoal);
            foreach (Goal g in _goals)
            {

                outputfile.WriteLine(g.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals()
    {
        Console.WriteLine("What is de filename for the goal file? ");
        string filenameLoad = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filenameLoad);
        _score = int.Parse(lines[0]);
        _lastEternalGoal = lines[1];
        lines = lines.Skip(1).ToArray();
        lines = lines.Skip(1).ToArray();
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            string[] nameAndType = parts[0].Split(":");
            Goal goal;
            string type = nameAndType[0];
            string goalName = nameAndType[1];
            string description = parts[1];
            string points = parts[2];
            string completed;
            string amountCompleted;
            string target;
            string bonus;
            if (type == "SimpleGoal")
            {
                completed = parts[3];
                goal = new SimpleGoal(goalName, description, int.Parse(points), bool.Parse(completed));
            }
            else if (type == "CheckListGoal")
            {
                bonus = parts[3];
                target = parts[4];
                amountCompleted = parts[5];
                goal = new CheckListGoal(goalName, description, int.Parse(points), int.Parse(target), int.Parse(bonus), int.Parse(amountCompleted));
            }
            else
            {
                goal = new EternalGoal(goalName, description, int.Parse(points));
            }
            _goals.Add(goal);

        }
    }

}