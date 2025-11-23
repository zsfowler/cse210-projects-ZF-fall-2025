using System;

// Base class for all goals.
// Other goal types inherit from this class.
public abstract class Goal
{
    // Protected so child classes can use them directly.
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

    // Public read-only properties so other classes can display values.
    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }

    public int Points
    {
        get { return _points; }
    }

    // Child classes must override these.
    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveFormat();
}
