using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let's create own team!");
        Console.Write("Enter team name: ");
        string teamName = Console.ReadLine()!;
        Team myTeam = new Team(teamName);

        Console.WriteLine("Let's do something in our team!\n");

        while(true)
        {
            Console.WriteLine("\nChoose something:");
            Console.WriteLine("1. Add developer");
            Console.WriteLine("2. Add manager");
            Console.WriteLine("3. Show bried info about team");
            Console.WriteLine("4. Show detailed info about team");
            Console.WriteLine("5. DO WORK EVERYONE!");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine()!;
            Console.WriteLine("\n\n");
            switch (choice)
            {
                case "1":
                    Console.Write("Enter developer name: ");
                    string devName = Console.ReadLine()!;
                    myTeam.AddWorker(new Developer(devName));
                    break;
                case "2":
                    Console.Write("Enter manager name: ");
                    string manName = Console.ReadLine()!;
                    myTeam.AddWorker(new Manager(manName));
                    break;
                
                case "3":
                    myTeam.ShowTeamInfo();
                    break;
                
                case "4":
                    myTeam.ShowDetailedInfo();
                    break;
                
                case "5":
                    myTeam.RunWork();
                    break;
                
                case "6":
                    Console.WriteLine("Thanks God!");
                    return;
                
                default:
                    Console.WriteLine("What do you choose? Are you serious?");
                    break;
            }
        }
    }
}

public abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string WorkDay { get; protected set; }

    public Worker(string name)
    {
        Name = name;
        Position = "";
        WorkDay = "";
    }

    public void Call()
    {
        Console.WriteLine($"{Name} is calling to someone, I don't know who.");
        WorkDay += "Call. ";
    }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} is writing code, I hope it's good.");
        WorkDay += "Write code. ";
    }

    public void Relax()
    {
        Console.WriteLine($"{Name} is relaxing, (baydyky b'ye)");
        WorkDay += "Relax. ";
    }

    public abstract void FillWorkDay();
}

public class Developer : Worker
{
    public Developer(string name) : base(name)
    {
        Position = "Developer";
    }

    public override void FillWorkDay()
    {
        Console.WriteLine($"\nWhat is {Name} doing?");
        WorkDay = "";
        WriteCode();
        Call();
        Relax();
        WriteCode();
        Console.WriteLine("Nothing special");
    }
}

public class Manager : Worker
{
    private Random random;
    public Manager(string name) : base(name)
    {
        Position = "Manager";
        random = new Random();
    }

    public override void FillWorkDay()
    {
        Console.WriteLine($"\nWhat is {Name} doing?");
        WorkDay = "";
        int calls = random.Next(1, 11);
        for (int i = 0; i < calls; i++)
        {
            Call();
        }
        Console.WriteLine($"Wow! The manager called {calls} times? Great!");

        Relax();

        calls = random.Next(1, 6);
        for (int i = 0; i < calls; i++)
        {
            Call();
        }
        Console.WriteLine($"Wow! The manager called {calls} times? Great!");
        Console.WriteLine("\nSomething special");
    }
}

public class Team
{
    public string Name { get; private set; }
    private List<Worker> workers;

    public Team(string name)
    {
        Name = name;
        workers = new List<Worker>();
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void RunWork() // I must create this method, but I don't wanna do this!
    {
        if (workers.Count == 0)
        {
            Console.WriteLine($"\nWhere is your workers?");
            return;
        }
        foreach (var worker in workers)
        {  
                worker.FillWorkDay();
        }
    }
    public void ShowTeamInfo()
    {
        Console.WriteLine($"Team: {Name}");
        foreach (var worker in workers)
        {
            Console.WriteLine(worker.Name);
        }
    }

    public void ShowDetailedInfo()
    {
        Console.WriteLine($"Team: {Name}");
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name} - {worker.Position} - {worker.WorkDay}");
        }
    }
}