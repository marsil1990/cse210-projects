using System;

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string nameStudent, string topic, string textBookSectio, string problems) : base(nameStudent, topic)
    {
        _textbookSection = textBookSectio;
        _problems = problems;
    }
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}