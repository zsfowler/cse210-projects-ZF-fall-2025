// This goal never ends. It can be recorded many times.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete()
    {
        // Eternal goals are never complete.
        return false;
    }

    public override int RecordEvent()
    {
        // Each time gives points.
        return _points;
    }

    public override string GetStatus()
    {
        return "[∞]";
    }

    public override string SaveFormat()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
