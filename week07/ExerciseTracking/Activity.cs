using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length;

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _length = duration;
    }
    public int GetLength()
    {
        return _length;
    }
    public abstract double GetSpeed();
    public abstract double GetDistance();
    public abstract double GetPace();
    public string GetSummary()
    {
        return $"{_date: dd MM yyyy} {this.GetType().Name} ({_length} min): Distance {GetDistance():0.0}, Speed: {GetSpeed():0.0} km/h, Pace: {GetPace():0.0} min/km";
    }
}