using System;
using System.Threading;

// Creativity on this program: log activity completion (For example, write to a file or display extra stats here we simply display a message)

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option (1-4): ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.DisplayStartingMessage();
            activity.Execute();
            activity.DisplayFinishingMessage();

            Console.WriteLine("Activity logged successfully.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
