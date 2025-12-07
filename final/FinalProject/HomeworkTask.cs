// Homework task type.
public class HomeworkTask : StudyTask
{
    private string _subject;

    public HomeworkTask(string title, string dueDate, int priority, string subject)
        : base(title, dueDate, priority)
    {
        _subject = subject;
    }

    public override int GetPoints()
    {
        return 50;
    }

    public override string GetSummary()
    {
        string status = _isDone ? "[X]" : "[ ]";
        return $"{status} Homework: {_title} (Subject: {_subject}) - Due: {_dueDate} - Priority: {_priority}";
    }
}
