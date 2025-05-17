using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Scriptures
{
    private List<Scripture> _scripture;

    public Scriptures()
    {
        _scripture = new List<Scripture>();
    }
    public void AddScriptures(Scripture s)
    {
        _scripture.Add(s);
    }

    public void GetDisplayText()
    {

        foreach (Scripture s in _scripture)
        {
            Console.WriteLine($"{_scripture.IndexOf(s)}: {s.GetDisplayText()}");

        }
    }
    public Scripture GetScripture(int number)
    {

        return _scripture[number];
    }

    public bool ExistScripture(int index)
    {
        return index >= 0 && index < _scripture.Count();
    }
    public void SaveToFile(Scripture scripture)
    {
        string fileName = "library.txt";

        using (StreamWriter outputFile = new StreamWriter(fileName, append: true))
        {


            outputFile.WriteLine($"{scripture.GetReference().GetDisplayText()}>{scripture.GetOnlyText()}");

        }
    }
    public List<Scripture> GetScriptures()
    {
        return _scripture;
    }
    public void loadFromFile()
    {
        string fileName = "library.txt";
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split(">");

            string refer = parts[0];
            string text = parts[1];

            string[] partsReference = refer.Split(" ");
            string book = partsReference[0];
            string[] secondPartsReference = partsReference[1].Split(":");
            string chapter = secondPartsReference[0];
            string endVerse;
            Reference reference;
            Scripture scripture;
            char ch = '.';
            string verse;
            foreach (char c in secondPartsReference[1])
            {
                if (c == '-')
                {
                    ch = '-';
                    string[] lastPartReference = secondPartsReference[1].Split("-");
                    verse = lastPartReference[0];
                    endVerse = lastPartReference[1];
                    reference = new Reference(book, int.Parse(chapter), int.Parse(verse), int.Parse(endVerse));
                    scripture = new Scripture(reference, text);
                    _scripture.Add(scripture);
                }
            }
            if (ch != '-')
            {
                verse = secondPartsReference[1];
                reference = new Reference(book, int.Parse(chapter), int.Parse(verse));
                scripture = new Scripture(reference, text);
                _scripture.Add(scripture);
            }


        }
    }
}