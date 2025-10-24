class Program
{
    static void Main(string[] args)
    {
        Converter converter = new Converter(42.06m, 48.04m);
        while (true)
        {
            Console.WriteLine("\nChoose, please: ");
            Console.WriteLine("1. UAH -> USD");
            Console.WriteLine("2. USD -> UAH");
            Console.WriteLine("3. UAH -> EUR");
            Console.WriteLine("4. EUR -> UAH");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    Console.Write("Enter the amount to convert:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine()!);
                    PerformConversion(converter, choice, amount);
                    break;

                case "5":
                    Console.WriteLine("Bye!");
                    return;

                default:
                    Console.WriteLine("What did you enter?");
                    break;
            }
        }
    }
    static void PerformConversion(Converter converter, string choice, decimal amount)
    {
        decimal result = 0;
        string currency = "";

        switch (choice)
        {
            case "1":
                result = converter.UahToUsd(amount);
                currency = "USD";
                break;
            case "2":
                result = converter.UsdToUah(amount);
                currency = "UAH";
                break;
            case "3":
                result = converter.UahToEur(amount);
                currency = "EUR";
                break;
            case "4":
                result = converter.EurToUah(amount);
                currency = "UAH";
                break;
        }

        Console.WriteLine($"Result: {result:F2} {currency}");
    }
    
}

public class Converter
{
    public decimal UsdRate { get; private set; }
    public decimal EurRate { get; private set; }

    public Converter(decimal usd, decimal eur)
    {
        UsdRate = usd;
        EurRate = eur;
    }

    public decimal UahToUsd(decimal uah)
    {
        return uah / UsdRate;
    }

    public decimal UsdToUah(decimal usd)
    {
        return usd * UsdRate;
    }

    public decimal UahToEur(decimal uah)
    {
        return uah / EurRate;
    }

    public decimal EurToUah(decimal eur)
    {
        return eur * EurRate;
    }
}