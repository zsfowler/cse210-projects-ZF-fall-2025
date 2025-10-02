using System;
using System.Collections.Generic;

public class Resume
{
    // persons name
    public string _personName;

    // list of jobs
    public List<Job> _jobs = new List<Job>();

    // resume display
    public void Display()
    {
        Console.WriteLine("Name: " + _personName);
        Console.WriteLine("Jobs:");
        
        // Go through each job and display it
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}
