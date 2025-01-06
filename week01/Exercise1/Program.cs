using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string name = Console.ReadLine().Trim();
        Console.Write("What is yout last name? ");
        string last = Console.ReadLine().Trim();
        Console.Write($"Your name is {last}, {name} {last}.");

    }
}