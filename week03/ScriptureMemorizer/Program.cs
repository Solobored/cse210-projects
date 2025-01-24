using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // The user can select the scripture they want
        // Shows how many words are left
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me.")
        };

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("\nSelect a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
        }

        Console.Write("\nEnter the number of the scripture you want to memorize: ");
        int choice = GetValidUserChoice(scriptures.Count);

        Scripture currentScripture = scriptures[choice - 1];

        while (!currentScripture.IsCompletelyHidden())
        {
            Console.WriteLine("\n" + new string('-', 60));
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine($"\nWords remaining visible: {currentScripture.GetVisibleWordCount()}");
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            currentScripture.HideRandomWords(3);
        }

        Console.WriteLine("\nThank you for using the Scripture Memorizer!");
    }

    static int GetValidUserChoice(int maxChoice)
    {
        int choice;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out choice) && choice >= 1 && choice <= maxChoice)
                break;
            Console.Write("Invalid input. Please enter a number between 1 and " + maxChoice + ": ");
        }
        return choice;
    }
}
