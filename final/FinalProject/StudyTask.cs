using System;

// Base class for all study tasks.
public abstract class StudyTask
{
    protected string _title;
    protected string _dueDate;
    protected int _priority;
    protected bool _isDone;

    public StudyTask(string title, string dueDate, int priority)
    {
        _title = title;
        _dueDate = dueDate;
        _priority = priority;
        _isDone = false;
    }

    public bool IsDone()
    {
        return _isDone;
    }

    public void MarkDone()
    {
        _isDone = true;
    }

    public abstract int GetPoints();
    public abstract string GetSummary();
}
