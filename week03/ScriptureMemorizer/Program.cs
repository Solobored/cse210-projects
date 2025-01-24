using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements: Create a list of scriptures to choose from randomly
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength.")
        };

        Random random = new Random();
        Scripture currentScripture = scriptures[random.Next(scriptures.Count)];

        while (!currentScripture.IsCompletelyHidden())
        {
            // Instead of clearing the console, print newlines and a separator
            Console.WriteLine("\n\n" + new string('-', 60) + "\n");
            
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            currentScripture.HideRandomWords(3);
        }

        Console.WriteLine("\nThank you for using the Scripture Memorizer!");
    }
}