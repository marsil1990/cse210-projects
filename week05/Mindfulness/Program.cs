using System;
using System.Data.Common;
/*
I added the following thins:
- The program doesn't repeat questions (Reflecting). The program ends when there are no more questions.
- When an activity is completed, it is saved on file called log.txt. (> day/month/year - Activity name - description - seconds)
- the method SaveToFile() was created in the Activity class.
- Also I added two method to the BreatheingActivity class : Inhale and Exhale, Both are animations.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string option = "";
        while (option != "4")
        {
            Console.WriteLine("Menu options: ");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                BreathingActivity a = new BreathingActivity("Breathing", "Relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing");
                a.Run();
            }
            else if (option == "3")
            {
                ListingActivity a = new ListingActivity("Listing", "reflect on the good things in your life by having you list as many things as you can in a certain area.");
                a.Run();
            }
            else if (option == "2")
            {
                ReflectingActivity a = new ReflectingActivity("Reflecting", "reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                a.Run();
            }

        }




    }
}