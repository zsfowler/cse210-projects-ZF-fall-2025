using System;
using System.Collections.Generic;

// Helps the user reflect on positive experiences
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you use this experience in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity helps you reflect on times when you showed strength and resilience.")
    { }

    // Runs the reflection activity
    public void Run()
    {
        StartActivity();
        Random random = new Random();

        // Pick a random prompt
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press Enter.");
        Console.ReadLine();

        Console.WriteLine("Now ponder these questions:");
        ShowCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        // Ask random questions until time runs out
        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine($"> {question}");
            ShowSpinner(4);
        }

        EndActivity();
    }
}
