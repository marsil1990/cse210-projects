using System;
public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        string[] jobText = _jobTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < jobText.Length; i++)
        {
            if (jobText[i].Length > 0)
            {
                string j = jobText[i];
                jobText[i] = char.ToUpper(j[0]) + j.Substring(1).ToLower();
            }
        }

        string[] companyText = _company.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < companyText.Length; i++)
        {
            if (companyText[i].Length > 0)
            {
                string c = companyText[i];
                companyText[i] = char.ToUpper(c[0]) + c.Substring(1).ToLower();
            }
        }


        string job = string.Join(" ", jobText);
        string company = string.Join(" ", companyText);
        Console.WriteLine($"{job} ({company}) {_startYear}-{_endYear}");
    }


}
