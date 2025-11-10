using System;

// Guides the user to breathe in and out
public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    { }

    // Runs the breathing activity
    public void Run()
    {
        StartActivity();
        int timeRemaining = GetDuration();

        while (timeRemaining > 0)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            timeRemaining -= 3;

            Console.Write("Now breathe out... ");
            ShowCountdown(3);
            timeRemaining -= 3;
        }

        EndActivity();
    }
}
