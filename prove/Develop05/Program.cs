using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // I added a simple leveling system in GoalManager.
        // Every 1000 points increases the level by 1.
        // The level shows on the menu.

        GoalManager manager = new GoalManager();
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine($"Current Score: {manager.Score}");
            Console.WriteLine($"Level: {manager.GetLevel()}");

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateNewGoal(manager);
            }
            else if (choice == "2")
            {
                manager.ShowGoals();
            }
            else if (choice == "3")
            {
                manager.RecordEvent();
            }
            else if (choice == "4")
            {
                SaveGoals(manager);
            }
            else if (choice == "5")
            {
                manager = LoadGoals();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("That is not a valid option. Try again.");
            }
        }
    }

    // Creates a new goal from user input.
    static void CreateNewGoal(GoalManager manager)
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            manager.AddGoal(goal);
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be done? ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for finishing it? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, targetCount, bonus);
            manager.AddGoal(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    // Saves goals to a file.
    static void SaveGoals(GoalManager manager)
    {
        Console.Write("\nEnter the filename to save to: ");
        string fileName = Console.ReadLine();

        SaveLoadHandler.Save(fileName, manager.GetGoals(), manager.Score);

        Console.WriteLine("Goals saved!");
    }

    // Loads goals from a file and returns a new manager.
    static GoalManager LoadGoals()
    {
        Console.Write("\nEnter the filename to load: ");
        string fileName = Console.ReadLine();

        var loadedData = SaveLoadHandler.Load(fileName);

        List<Goal> goals = loadedData.Item1;
        int score = loadedData.Item2;

        GoalManager newManager = new GoalManager();

        foreach (Goal g in goals)
        {
            newManager.AddGoal(g);
        }

        newManager.SetScore(score);

        Console.WriteLine("Goals loaded!");
        return newManager;
    }
}
