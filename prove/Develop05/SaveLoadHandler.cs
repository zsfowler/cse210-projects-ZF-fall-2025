using System;
using System.Collections.Generic;
using System.IO;

// This handles saving and loading goals from a text file.
public static class SaveLoadHandler
{
    // Saves the score and all goals.
    public static void Save(string fileName, List<Goal> goals, int score)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(score);

            foreach (Goal g in goals)
            {
                writer.WriteLine(g.SaveFormat());
            }
        }
    }

    // Loads goals and score, then returns them.
    public static (List<Goal>, int) Load(string fileName)
    {
        List<Goal> goals = new List<Goal>();

        if (!File.Exists(fileName))
        {
            return (goals, 0);
        }

        string[] lines = File.ReadAllLines(fileName);

        int score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (type == "Simple")
            {
                bool completed = bool.Parse(parts[4]);
                SimpleGoal sg = new SimpleGoal(name, description, points);

                if (completed)
                {
                    sg.RecordEvent();
                }

                goals.Add(sg);
            }
            else if (type == "Eternal")
            {
                goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "Checklist")
            {
                int bonus = int.Parse(parts[4]);
                int targetCount = int.Parse(parts[5]);
                int currentCount = int.Parse(parts[6]);

                ChecklistGoal cg = new ChecklistGoal(name, description, points, targetCount, bonus);

                // Restore progress without giving points again.
                cg.SetCurrentCount(currentCount);

                goals.Add(cg);
            }
        }

        return (goals, score);
    }
}
