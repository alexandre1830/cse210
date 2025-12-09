using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        
        int standardPoints = int.Parse(Points);
        int pointsEarned = standardPoints;

        if (_amountCompleted == _target)
        {
            pointsEarned += _bonus;
            Console.WriteLine($"Congratulations! You have earned {standardPoints} + {_bonus} bonus points!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {standardPoints} points!");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {ShortName} ({Description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{_bonus},{_target},{_amountCompleted}";
    }
}