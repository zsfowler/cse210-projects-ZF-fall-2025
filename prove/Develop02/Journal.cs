using System;
using System.Collections.Generic;
using System.IO;

public class Journal
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
