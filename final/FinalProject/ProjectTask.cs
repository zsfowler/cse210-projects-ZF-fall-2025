// Project task type.
public class ProjectTask : StudyTask
{
    private bool _isGroupProject;

    public ProjectTask(string title, string dueDate, int priority, bool isGroupProject)
        : base(title, dueDate, priority)
    {
        _isGroupProject = isGroupProject;
    }

    public override int GetPoints()
    {
        if (_isGroupProject)
        {
            return 100;
        }
        else
        {
            return 80;
        }
    }

    public override string GetSummary()
    {
        string status = _isDone ? "[X]" : "[ ]";
        string typeText = _isGroupProject ? "Group Project" : "Solo Project";
        return $"{status} Project: {_title} ({typeText}) - Due: {_dueDate} - Priority: {_priority}";
    }
}
