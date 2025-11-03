using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter an integer: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        Console.WriteLine($"You entered the number {number}");
        Console.ReadKey();
    }
}