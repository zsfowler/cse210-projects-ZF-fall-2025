// This goal is finished once.
// Example: run a marathon one time.
public class SimpleGoal : Goal
{
    private bool _completed;

    // Constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    // True if done.
    public override bool IsComplete()
    {
        return _completed;
    }

    // Gives points only the first time.
    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }

        return 0;
    }

    // Shows [X] when complete.
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

    // Save format for file.
    public override string SaveFormat()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_completed}";
    }
}
