using System;

public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = 0;
    }
    public CheckListGoal(string name, string description, int points, int target, int bonus, int amount) : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _amountCompleted = amount;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override int GetBonus()
    {
        return _bonus;
    }

    public override int GetamountCompleted()
    {
        return _amountCompleted;
    }


    public override bool IsComplete()
    {
        if (_target <= _amountCompleted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public override string getDetailsString()
    {
        return $" -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"CheckListGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
    }

}