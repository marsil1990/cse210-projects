using System;
/*
The following features were added: The user can add new scriptures, which are saved in a file called library.txt.
 A menu was also added so the user can load the scriptures and select one.*/
class Program
{
    static void Main(string[] args)
    {
        Scriptures scriptures = new Scriptures();

        string option = "";
        while (option != "4")
        {
            Console.WriteLine("Scripture Memorization Program");
            Console.WriteLine("1. Enter a new Scripture to Memorize");
            Console.WriteLine("2. Start Memorization Session");
            Console.WriteLine("3. Load scriptures from a file called library.txt");
            Console.WriteLine("4. Exit Program");
            Console.Write("Please enter a numeric option: ");
            option = Console.ReadLine();
            Console.WriteLine("=========================================================================================================");
            if (option == "1")
            {
                Console.Write("Enter a book: ");
                string book = Console.ReadLine();
                Console.Write("Enter a chapter: ");
                int chapterNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter a verse (the first number verse): ");
                int verseNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter the final verse. if it is only one verse, enter the same number: ");
                int endVerseNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter the verse text: ");
                string text = Console.ReadLine();
                Reference reference;
                if (verseNumber == endVerseNumber)
                {
                    reference = new Reference(book, chapterNumber, verseNumber);
                }
                else
                {
                    reference = new Reference(book, chapterNumber, verseNumber, endVerseNumber);
                }
                Scripture scripture = new Scripture(reference, text);
                scriptures.AddScriptures(scripture);
                Console.WriteLine("The scripture will be save on file calling library.txt");
                scriptures.SaveToFile(scripture);
                Console.WriteLine("=========================================================================================================");
            }
            else if (option == "2")
            {
                if (scriptures.GetScriptures().Count() != 0)
                {
                    scriptures.GetDisplayText();
                    Console.Write("Select a scripture. Enter its number: ");
                    int scriptureNumber = int.Parse(Console.ReadLine());
                    if (scriptures.ExistScripture(scriptureNumber))
                    {
                        Scripture scripture = scriptures.GetScripture(scriptureNumber);
                        scripture.GetDisplayText();
                        string type = "";
                        while (type.ToLower() != "quit")
                        {
                            Console.Write("Press enter to hide a random words or and continue or type 'quit' and press enter to end the session: ");
                            type = Console.ReadLine();
                            if (type.ToLower() != "quit")
                            {
                                scripture.HideRandomWords(2);
                                Console.WriteLine(scripture.GetDisplayText());

                            }
                            if (scripture.IsCompleteHidden())
                            {
                                type = "quit";
                                option = "4";
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Incorrect number");
                    }

                }
            }
            else if (option == "3")
            {
                scriptures.loadFromFile();
            }
            else
            {
                option = "4";

            }
        }


    }
}