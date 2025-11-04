using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter an integer: ");
        string input = Console.ReadLine();
        Console.WriteLine($"You entered the number {input}");
        Console.ReadKey();
    }
}