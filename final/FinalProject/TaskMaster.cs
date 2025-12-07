using System;
using System.Collections.Generic;

// Manages all study tasks.
public class TaskManager
{
    private List<StudyTask> _tasks = new List<StudyTask>();
    private int _tasksCompleted;

    public TaskManager()
    {
        _tasksCompleted = 0;
    }

    public void AddTask(StudyTask task)
    {
        _tasks.Add(task);
    }

    public void ShowAllTasks()
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks yet.");
            return;
        }

        Console.WriteLine("\nYour tasks:\n");

        for (int i = 0; i < _tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_tasks[i].GetSummary()}");
        }
    }

    public void CompleteTask(Student student, BreakPlan breakPlan)
    {
        if (_tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks to complete.");
            return;
        }

        ShowAllTasks();
        Console.Write("\nEnter the number of the task you finished: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _tasks.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        StudyTask task = _tasks[index];

        if (task.IsDone())
        {
            Console.WriteLine("Task already done.");
            return;
        }

        task.MarkDone();

        int points = task.GetPoints(); // polymorphism happens here
        student.AddPoints(points);

        _tasksCompleted++;

        Console.WriteLine($"\nGreat job! You earned {points} points.");

        string suggestion = breakPlan.GetBreakSuggestion(_tasksCompleted);
        if (suggestion != "")
        {
            Console.WriteLine("\nBreak Suggestion: " + suggestion);
        }
    }
}
