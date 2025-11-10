using System;
using System.Collections.Generic;

// Lets the user list positive things
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "When have you felt peace recently?",
        "Who are your heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity helps you reflect on the good things in your life by listing as many items as you can.")
    { }

    // Runs the listing activity
    public void Run()
    {
        StartActivity();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        // Show prompt and countdown
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        // Let user type items until time runs out
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items!");
        EndActivity();
    }
}
