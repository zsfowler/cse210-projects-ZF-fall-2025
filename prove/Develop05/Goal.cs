using System;

// This is the base class for all goals.
public abstract class Goal
{
    // Shared attributes for all goals.
    protected string _name;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Simple "getter" methods instead of properties.
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Methods that each child class must override.
    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveFormat();
}
