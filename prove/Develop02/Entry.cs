using System;

public class Entry
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
