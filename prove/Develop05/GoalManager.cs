using System;
using System.Collections.Generic;

// This class holds all goals and the user's score.
public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Read-only score property.
    public int Score
    {
        get { return _score; }
    }

    // Creativity: simple level system.
    // Every 1000 points increases the level by 1.
    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    // Adds a goal to the list.
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Adds points to score.
    public void AddScore(int points)
    {
        _score += points;
    }

    // Displays all goals in a list.
    public void ShowGoals()
    {
        Console.WriteLine("\nHere are your goals:\n");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal g = _goals[i];

            Console.WriteLine($"{i + 1}. {g.GetStatus()} {g.Name} - {g.Description}");
        }
    }

    // Lets user record doing a goal.
    public void RecordEvent()
    {
        ShowGoals();
        Console.Write("\nWhich goal did you complete? Enter the number: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            int earnedPoints = _goals[choice].RecordEvent();
            AddScore(earnedPoints);

            Console.WriteLine($"\nYou earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    // Returns the list so Save can write them.
    public List<Goal> GetGoals()
    {
        return _goals;
    }

    // Used when loading a file.
    public void SetScore(int score)
    {
        _score = score;
    }
}
