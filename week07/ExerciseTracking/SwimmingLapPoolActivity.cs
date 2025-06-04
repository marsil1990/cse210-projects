using System;

public class SwimmingLapPoolActivity : Activity
{
    private int _numberOfLaps;

    public SwimmingLapPoolActivity(DateTime date, int duration, int numberLap) : base(date, duration)
    {
        _numberOfLaps = numberLap;
    }
    public override double GetSpeed()
    {
        return (GetDistance() / GetLength()) * 60;
    }
    public override double GetDistance()
    {
        return _numberOfLaps * 50 / 1000;
    }
    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }

}
