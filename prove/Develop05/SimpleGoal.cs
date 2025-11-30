// This goal is completed one time and then it is done.
public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }

        // No more points after it is done.
        return 0;
    }

    public override string GetStatus()
    {
        if (_completed)
        {
            return "[X]";
        }
        else
        {
            return "[ ]";
        }
    }

    public override string SaveFormat()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_completed}";
    }
}
