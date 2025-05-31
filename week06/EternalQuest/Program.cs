using System;
/*
I added the following to the program :
In GoalManager, I added a new atribute named _lastEternalGoal, this atribute stores the date when the user last worked on a eternal goal.
Additionally, the program displays information to the user such as: "The last time you worked on an Eternal Goal was 4 days ago" or "You haven't worked on an Eternal Goal"
*/
class Program
{
    static void Main(string[] args)
    {

        GoalManager goals = new GoalManager();
        goals.Start();

    }
}