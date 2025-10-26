using System;

class Program
{
    static void Main(string[] args)
    {
        // make a reference for the scripture (Proverbs 3:5–6)
        Reference r = new Reference("Proverbs", 3, 5, 6);

        // this is the text of the scripture
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";

        // make a new scripture using the reference and text
        Scripture s = new Scripture(r, text);

        // loop until the user quits or all words are hidden
        while (true)
        {
            Console.Clear(); // clears the console so it looks new
            Console.WriteLine(s.GetDisplayText()); // shows the scripture
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to end:");
            string input = Console.ReadLine(); // get what the user typed

            // if user types quit, stop the program
            if (input.ToLower() == "quit")
            {
                break;
            }

            // hide 3 random words
            s.HideRandomWords(3);

            // stop when all words are hidden
            if (s.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(s.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Nice job!");
                break;
            }
        }
    }
}
