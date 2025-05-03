using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        DisplayWecome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        number = SquareNumber(number);
        DisplayResult(name, number);
    }

    static void DisplayWecome(){
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }

    static int SquareNumber(int number){
        return number*number;
    }

    static void DisplayResult(string userName, int squareNumber){
        Console.WriteLine($"Brother {userName}, the square of your number is {squareNumber}");
    }
}