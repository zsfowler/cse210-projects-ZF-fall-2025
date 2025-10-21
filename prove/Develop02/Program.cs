using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("=== Journal Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");
            Console.Write("Pick a number: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                myJournal.WriteEntry();
            }
            else if (choice == "2")
            {
                myJournal.ShowJournal();
            }
            else if (choice == "3")
            {
                Console.Write("Enter file name: ");
                string file = Console.ReadLine();
                myJournal.SaveFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("Enter file name: ");
                string file = Console.ReadLine();
                myJournal.LoadFile(file);
            }
            else if (choice == "5")
            {
                quit = true;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("That’s not a valid choice. Try again.");
            }

            Console.WriteLine();
        }
    }
}
