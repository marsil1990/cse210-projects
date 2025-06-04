using System;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }
    public override double GetSpeed()
    {
        return (_distance / GetLength()) * 60;
    }
    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetPace()
    {
        return GetLength() / _distance;
    }

}

