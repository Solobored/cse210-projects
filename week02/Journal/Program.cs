using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("\nJournal Program");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Analyze mood trends");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("How are you feeling today? (e.g., happy, sad, excited): ");
                    string mood = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    journal.AddEntry(new Entry(date, prompt, response, mood));
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    journal.AnalyzeMoodTrends();
                    break;

                case "6":
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

// Exceeding Requirements:
// 1. Added mood tracking to each journal entry, allowing users to record their emotional state.
// 2. Implemented a mood trend analysis feature that shows the frequency of different moods.
// 3. Used LINQ for efficient data processing in the mood trend analysis.
// 4. Implemented a more detailed timestamp for entries, including both date and time.
// 5. Used proper C# naming conventions throughout the program.
// 6. Organized code into separate files for each class, promoting better maintainability.
// 7. Implemented error handling for file operations (not shown in this simplified version).