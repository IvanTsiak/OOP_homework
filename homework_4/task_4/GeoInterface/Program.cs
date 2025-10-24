class Program
{
    static void Main(string[] args)
    {
        IGeoObject river = new River(16.48, 50.73, "Lowkey", "Cooooooooool river for cooooooool person", 40.0, 1062.0);
        IGeoObject mountain = new Mountain(48.16, 89.50, "MountainDew", "Very freshy mountain", 2561.0);

        Console.WriteLine(river.GetInfo());
        Console.WriteLine();
        Console.WriteLine(mountain.GetInfo());
    }
}

public interface IGeoObject
{
    double X { get; set; }
    double Y { get; set; }
    string Name { get; set; }
    string Description { get; set; }

    string GetInfo();
}

public class River : IGeoObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public double FlowSpeed { get; set; }
    public double Length { get; set; }

    public River(double x, double y, string name, string description, double speed, double length)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        FlowSpeed = speed;
        Length = length;
    }

    public string GetInfo()
    {
        return $"Name: {Name}\ncoordinates: ({X}; {Y})\nDescription: {Description}" +
               $"\nType: River\nFlow speed: {FlowSpeed} cm/s\nLenght: {Length} kilometers";
    }
}

public class Mountain : IGeoObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public double HighestPoint { get; set; }

    public Mountain(double x, double y, string name, string description, double highestPoint)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
        HighestPoint = highestPoint;
    }

    public string GetInfo()
    {
        return $"Name: {Name}\ncoordinates: ({X}; {Y})\nDescription: {Description}" +
                $"\nType: Mountain\nHighest point: {HighestPoint} meters";
    }
}