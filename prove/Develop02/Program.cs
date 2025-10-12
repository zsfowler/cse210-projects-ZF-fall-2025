using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    // makes an entry
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    // shows an entry
    public void ShowEntry()
    {
        Console.WriteLine(_date + " - " + _prompt);
        Console.WriteLine("Answer: " + _response);
        Console.WriteLine(); // blank line
    }

    // public getters for saving/loading
    public string Date { get { return _date; } }
    public string Prompt { get { return _prompt; } }
    public string Response { get { return _response; } }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I talked to today?",
        "What was the best part of my day?",
        "How did I see something good happen today?",
        "What was the strongest feeling I had today?",
        "If I could do one thing over today, what would it be?"
    };

    // makes a journal entry
    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("Your answer: ");
        string answer = Console.ReadLine();

        string today = DateTime.Now.ToShortDateString();

        Entry newEntry = new Entry(today, prompt, answer);
        _entries.Add(newEntry);

        Console.WriteLine("Entry saved!");
    }

    // shows the entries
    public void ShowJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.ShowEntry();
            }
        }
    }

    // saves to file
    public void SaveFile(string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                sw.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved!");
    }

    // loads from file
    public void LoadFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded!");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

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