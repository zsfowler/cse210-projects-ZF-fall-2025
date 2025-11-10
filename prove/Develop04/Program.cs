using System;

public class Program
{
    public static void Main(string[] args)
    {
        bool quit = false;

        // Track how many times each activity is done
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        while (!quit)
        {
            // Show main menu
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Breathing Activity");
            Console.WriteLine("  2. Reflection Activity");
            Console.WriteLine("  3. Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            // Run selected activity and track totals
            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                activity.Run();
                reflectionCount++;
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                listingCount++;
            }
            else if (choice == "4")
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
                Console.ReadLine();
            }
        }

        // Show session summary before closing
        Console.Clear();
        Console.WriteLine("Session Summary:");
        Console.WriteLine($"  Breathing Activities done:  {breathingCount}");
        Console.WriteLine($"  Reflection Activities done: {reflectionCount}");
        Console.WriteLine($"  Listing Activities done:    {listingCount}");
        Console.WriteLine();
        Console.WriteLine("Thank you for taking time to be mindful today!");
        Console.WriteLine("Press Enter to close the program...");
        Console.ReadLine();
    }
}

//Feature Added:
//a session log that counts how many times each 
//activity type was completed during the program run.
//When the user quits, a summary report appears showing
//how many breathing, reflection, and listing activities 
//they completed.


