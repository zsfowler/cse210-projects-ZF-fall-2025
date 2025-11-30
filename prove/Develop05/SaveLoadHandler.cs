using System;
using System.Collections.Generic;
using System.IO;

// This class saves and loads goals to a file.
public static class SaveLoadHandler
{
    public static void Save(string fileName, List<Goal> goals, int score)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            // First line is the score.
            writer.WriteLine(score);

            // Each other line is one goal.
            foreach (Goal g in goals)
            {
                writer.WriteLine(g.SaveFormat());
            }
        }
    }

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
                    // Mark as completed once.
                    sg.RecordEvent();
                }

                goals.Add(sg);
            }
            else if (type == "Eternal")
            {
                EternalGoal eg = new EternalGoal(name, description, points);
                goals.Add(eg);
            }
            else if (type == "Checklist")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);

                ChecklistGoal cg = new ChecklistGoal(name, description, points, target, bonus);
                cg.SetCurrentCount(current);

                goals.Add(cg);
            }
        }

        return (goals, score);
    }
}
