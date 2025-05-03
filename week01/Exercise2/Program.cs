using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string letter;
        if (grade >= 90){
            letter = "A";
        }
        else if (grade >= 80){
            letter = "B";
        }
        else if (grade >= 70){
            letter = "C";
        }
        else if (grade >= 60){
            letter = "D";
        }
        else{
            letter = "F";
        }

        string sign ="";
        int lastDigit = grade % 10;
        if (lastDigit >= 7){
            sign = "+";
        }
        else if (lastDigit < 3){
            sign = "-";
        }
      
        if (letter == "F"){
            Console.WriteLine($"Your letter grade is {letter}");
        }
        else if (letter == "A" && lastDigit>=3){
            Console.WriteLine($"Your letter grade is {letter}");
        }
        else{
            Console.WriteLine($"Your letter grade is {letter}{sign}");
        }

    
        if (grade >= 70){
            Console.WriteLine("Congratulations! You passed the class");
        }
        else {
            Console.WriteLine("You did not pass the class. Keep trying!");
        }

    }
}