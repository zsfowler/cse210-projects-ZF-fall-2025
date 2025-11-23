// This goal must be done a set number of times.
// Example: attend the temple 10 times.
public class ChecklistGoal : Goal
{
    private int _targetCount;   // needed to finish
    private int _currentCount;  // progress so far
    private int _bonus;         // extra points at the end

    // Constructor
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    // Lets the Load method restore progress safely.
    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    // True if we've reached the target.
    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    // Adds 1 progress and returns points (plus bonus if finished).
    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;

            if (_currentCount == _targetCount)
            {
                return _points + _bonus;
            }

            return _points;
        }

        return 0;
    }

    // Shows progress like Completed 2/5 times.
    public override string GetStatus()
    {
        string checkbox;

        if (IsComplete())
        {
            checkbox = "[X]";
        }
        else
        {
            checkbox = "[ ]";
        }

        return $"{checkbox} Completed {_currentCount}/{_targetCount}";
    }

    // Save format for file.
    public override string SaveFormat()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}
