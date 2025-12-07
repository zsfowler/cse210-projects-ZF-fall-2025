using System;
using System.Collections.Generic;

// Suggests breaks after tasks.
public class BreakPlan
{
    private List<string> _breakIdeas;

    public BreakPlan()
    {
        _breakIdeas = new List<string>();
        _breakIdeas.Add("Stretch for 2 minutes.");
        _breakIdeas.Add("Walk around the room.");
        _breakIdeas.Add("Drink some water.");
        _breakIdeas.Add("Rest your eyes for a moment.");
    }

    public string GetBreakSuggestion(int tasksCompleted)
    {
        if (tasksCompleted > 0 && tasksCompleted % 3 == 0)
        {
            int index = (tasksCompleted / 3 - 1) % _breakIdeas.Count;
            return _breakIdeas[index];
        }

        return "";
    }
}
