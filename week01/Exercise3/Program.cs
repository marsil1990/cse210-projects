using System;

class Program
{
    static void Main(string[] args)
    {
        string play = "yes";
        while  (play == "yes"){  
            Random randomGenerator = new Random();
            int numberMagic = randomGenerator.Next(1, 11);
            Console.WriteLine("We going to generate a magic number between 1 and 10, you need to try to gess");
            int numberGuess;
            int guesses = 0;
            do 
            {
                Console.Write("What is your guess? ");
                string number = Console.ReadLine();
                numberGuess = int.Parse(number);
                guesses ++;
                if (numberMagic == numberGuess){
                    Console.WriteLine($"You guessed it!, you tried {guesses} time");
                }
                else if (numberMagic > numberGuess){
                    Console.WriteLine("Higher");
                }
                else{
                    Console.WriteLine("Lower");
                }
            
            }
            while (numberGuess != numberMagic);
            Console.Write("Do you want play again? yes/no: " );
            play =  Console.ReadLine();
            play = play.ToLower().Replace(" ", "");
        }

    }
}