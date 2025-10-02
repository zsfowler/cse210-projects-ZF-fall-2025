using System;

public class Job
{
    // variables
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    // job details
    public void Display()
    {
        Console.WriteLine(_jobTitle + " (" + _company + ") " + _startYear + "-" + _endYear);
    }
}
