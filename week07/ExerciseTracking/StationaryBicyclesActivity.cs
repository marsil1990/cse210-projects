using System;

public class StationaryBicyclesActivity : Activity
{
    private double _speed;

    public StationaryBicyclesActivity(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetDistance()
    {
        return _speed * GetLength();
    }
    public override double GetPace()
    {
        return GetLength() / GetDistance();
    }

}
