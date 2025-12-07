// Gives titles based on points.
public class RewardSystem
{
    public string GetTitleForPoints(int points)
    {
        if (points < 100)
        {
            return "New Student";
        }
        else if (points < 300)
        {
            return "Hard Worker";
        }
        else if (points < 600)
        {
            return "Study Warrior";
        }
        else
        {
            return "Study Master";
        }
    }
}
