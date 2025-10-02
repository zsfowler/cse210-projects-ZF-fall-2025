using System;

class Program
{
    static void Main(string[] args)
    {
        // first job
        Job job1 = new Job();
        job1._jobTitle = "Customer Support Specialist";
        job1._company = "Best Buy";
        job1._startYear = 2018;
        job1._endYear = 2020;

        // second job
        Job job2 = new Job();
        job2._jobTitle = "Network Administrator";
        job2._company = "Verizon";
        job2._startYear = 2020;
        job2._endYear = 2023;

        // resume
        Resume myResume = new Resume();
        myResume._personName = "Jordan Smith";

        // Add to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // display resume
        myResume.Display();
    }
}
