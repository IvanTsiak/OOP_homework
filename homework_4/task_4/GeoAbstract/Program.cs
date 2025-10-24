class Program
{
    static void Main(string[] args)
    {
        GeoObject river = new River(16.48, 50.73, "Lowkey", "Cooooooooool river for cooooooool person", 40.0, 1062.0);
        GeoObject mountain = new Mountain(48.16, 89.50, "MountainDew", "Very freshy mountain", 2561.0);

        Console.WriteLine(river.GetInfo());
        Console.WriteLine();
        Console.WriteLine(mountain.GetInfo());
    }
}

public abstract class GeoObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public GeoObject(double x, double y, string name, string description)
    {
        X = x;
        Y = y;
        Name = name;
        Description = description;
    }

    public virtual string GetInfo()
    {
        return $"Name: {Name}\ncoordinates: ({X}; {Y})\nDescription: {Description}";
    }
}

public class River : GeoObject
{
    public double FlowSpeed { get; set; }
    public double Length { get; set; }

    public River(double x, double y, string name, string description, double speed, double length)
        : base(x, y, name, description)
    {
        FlowSpeed = speed;
        Length = length;
    }

    public override string GetInfo()
    {
        string baseInfo = base.GetInfo();
        return $"{baseInfo}\nType: River\nFlow speed: {FlowSpeed} cm/s\nLenght: {Length} kilometers";
    }
}

public class Mountain : GeoObject
{
    public double HighestPoint { get; set; }

    public Mountain(double x, double y, string name, string description, double highestPoint)
        : base(x, y, name, description)
    {
        HighestPoint = highestPoint;
    }

    public override string GetInfo()
    {
        string baseInfo = base.GetInfo();
        return $"{baseInfo}\nType: Mountain\nHighest point: {HighestPoint} meters";
    }
}