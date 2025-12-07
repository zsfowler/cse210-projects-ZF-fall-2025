// Reading assignment task.
public class ReadingTask : StudyTask
{
    private int _pageCount;

    public ReadingTask(string title, string dueDate, int priority, int pageCount)
        : base(title, dueDate, priority)
    {
        _pageCount = pageCount;
    }

    public override int GetPoints()
    {
        int points = _pageCount / 5;
        if (points < 10)
        {
            points = 10;
        }
        return points;
    }

    public override string GetSummary()
    {
        string status = _isDone ? "[X]" : "[ ]";
        return $"{status} Reading: {_title} ({_pageCount} pages) - Due: {_dueDate} - Priority: {_priority}";
    }
}
