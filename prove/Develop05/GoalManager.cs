using System;
using System.Collections.Generic;

// This class keeps track of goals and the total score.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Return the current score (no property).
    public int GetScore()
    {
        return _score;
    }

    // Simple "extra" feature: level based on score.
    public int GetLevel()
    {
        // Every 1000 points is a new level.
        return (_score / 1000) + 1;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void AddScore(int points)
    {
        _score += points;
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nHere are your goals:\n");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal g = _goals[i];
            Console.WriteLine($"{i + 1}. {g.GetStatus()} {g.GetName()} - {g.GetDescription()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nYou do not have any goals yet.");
            return;
        }

        ShowGoals();
        Console.Write("\nWhich goal did you complete? Enter the number: ");
        string input = Console.ReadLine();
        int choice;

        if (!int.TryParse(input, out choice))
        {
            Console.WriteLine("That is not a number.");
            return;
        }

        int index = choice - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That is not a valid goal.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"\nYou earned {earned} points!");
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void SetScore(int score)
    {
        _score = score;
    }
}
