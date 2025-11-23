// This goal never ends.
// Example: read scriptures daily.
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Eternal goals are never completed.
    public override bool IsComplete()
    {
        return false;
    }

    // Each time you do it, you get points.
    public override int RecordEvent()
    {
        return _points;
    }

    // Uses infinity symbol for fun.
    public override string GetStatus()
    {
        return "[∞]";
    }

    // Save format for file.
    public override string SaveFormat()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
