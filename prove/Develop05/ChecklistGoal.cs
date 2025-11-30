// This goal must be completed a certain number of times.
public class ChecklistGoal : Goal
{
    private int _targetCount;   // needed times
    private int _currentCount;  // times done so far
    private int _bonus;         // extra points at the end

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    // Used when loading from a file to restore progress.
    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;

            if (_currentCount == _targetCount)
            {
                // Final time gives normal points + bonus.
                return _points + _bonus;
            }

            return _points;
        }

        // Already finished, no more points.
        return 0;
    }

    public override string GetStatus()
    {
        string box;

        if (IsComplete())
        {
            box = "[X]";
        }
        else
        {
            box = "[ ]";
        }

        return $"{box} Completed {_currentCount}/{_targetCount}";
    }

    public override string SaveFormat()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}
