// Quiz task type.
public class QuizTask : StudyTask
{
    private int _questionCount;

    public QuizTask(string title, string dueDate, int priority, int questionCount)
        : base(title, dueDate, priority)
    {
        _questionCount = questionCount;
    }

    public override int GetPoints()
    {
        int points = (_questionCount / 5) * 5;
        if (points < 20)
        {
            points = 20;
        }
        return points;
    }

    public override string GetSummary()
    {
        string status = _isDone ? "[X]" : "[ ]";
        return $"{status} Quiz: {_title} ({_questionCount} questions) - Due: {_dueDate} - Priority: {_priority}";
    }
}
