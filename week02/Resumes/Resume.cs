using System;
public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();


    public void Display()
    {
        string[] nameText = _name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < nameText.Length; i++)
        {
            if (nameText[i].Length > 0)
            {
                string n = nameText[i];
                nameText[i] = char.ToUpper(n[0]) + n.Substring(1).ToLower();
            }
        }
        string name = string.Join(" ", nameText);
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }


}