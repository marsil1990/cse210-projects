using System;
using System.Threading;
using System.Globalization;
using System.Threading;



class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        RunningActivity r = new RunningActivity(new DateTime(2025, 6, 5), 30, 4.8);
        StationaryBicyclesActivity b = new StationaryBicyclesActivity(new DateTime(2025, 6, 6), 45, 20.0);
        SwimmingLapPoolActivity s = new SwimmingLapPoolActivity(new DateTime(2025, 6, 8), 30, 20);
        List<Activity> activityList = new List<Activity>();
        activityList.Add(r);
        activityList.Add(b);
        activityList.Add(s);
        foreach (Activity a in activityList)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}