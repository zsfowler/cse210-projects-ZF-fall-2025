using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Study Buddy Planner!");
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        Student student = new Student(name);
        TaskManager taskManager = new TaskManager();
        BreakPlan breakPlan = new BreakPlan();
        RewardSystem rewardSystem = new RewardSystem();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"Student: {student.Name}");
            Console.WriteLine($"Points: {student.Points}");
            Console.WriteLine($"Title: {rewardSystem.GetTitleForPoints(student.Points)}");
            Console.WriteLine("---------------------------");

            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Complete a task");
            Console.WriteLine("4. Show status");
            Console.WriteLine("5. Quit");
            Console.Write("Choose one: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                AddNewTask(taskManager);
            }
            else if (choice == "2")
            {
                taskManager.ShowAllTasks();
            }
            else if (choice == "3")
            {
                taskManager.CompleteTask(student, breakPlan);
            }
            else if (choice == "4")
            {
                ShowStatus(student, rewardSystem);
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nGoodbye!");
            }
            else
            {
                Console.WriteLine("Not a valid choice.");
            }
        }
    }

    static void AddNewTask(TaskManager taskManager)
    {
        Console.WriteLine("\nTask Types:");
        Console.WriteLine("1. Homework");
        Console.WriteLine("2. Reading");
        Console.WriteLine("3. Quiz");
        Console.WriteLine("4. Project");
        Console.Write("Select type: ");
        string type = Console.ReadLine();

        Console.Write("Enter title: ");
        string title = Console.ReadLine();

        Console.Write("Enter due date: ");
        string dueDate = Console.ReadLine();

        Console.Write("Enter priority (1-5): ");
        int priority = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();

            taskManager.AddTask(new HomeworkTask(title, dueDate, priority, subject));
        }
        else if (type == "2")
        {
            Console.Write("Enter page count: ");
            int pages = int.Parse(Console.ReadLine());

            taskManager.AddTask(new ReadingTask(title, dueDate, priority, pages));
        }
        else if (type == "3")
        {
            Console.Write("Enter number of questions: ");
            int questions = int.Parse(Console.ReadLine());

            taskManager.AddTask(new QuizTask(title, dueDate, priority, questions));
        }
        else if (type == "4")
        {
            Console.Write("Is this a group project? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            bool isGroup = (answer == "yes");

            taskManager.AddTask(new ProjectTask(title, dueDate, priority, isGroup));
        }
        else
        {
            Console.WriteLine("Invalid type.");
        }
    }

    static void ShowStatus(Student student, RewardSystem rewardSystem)
    {
        Console.WriteLine("\n==== STATUS ====");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Points: {student.Points}");
        Console.WriteLine($"Title: {rewardSystem.GetTitleForPoints(student.Points)}");
        Console.WriteLine("================");
    }
}
