using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
     //I have included a User class which will track a score, and the user's level increases every 1000 points
     //I have added like in Duaolingo a streak bonus for Eternal Goals
     //I have added a NegativeGoal class which tracks bad habits now whenever you record a negative goal it will subtract points

    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static User user = new User();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Eternal Quest Menu ---");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Display Score and Achievements");
                Console.WriteLine("5. Save Progress");
                Console.WriteLine("6. Load Progress");
                Console.WriteLine("7. Quit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        Console.WriteLine(user);
                        break;
                    case "5":
                        SaveProgress();
                        break;
                    case "6":
                        LoadProgress();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
        {
            Console.WriteLine("\nSelect the type of goal to create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("4. Negative Goal (Bad Habit)");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter base points (or penalty for Negative Goal): ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            if (typeChoice == "1")
            {
                newGoal = new SimpleGoal(name, description, points);
            }
            else if (typeChoice == "2")
            {
                newGoal = new EternalGoal(name, description, points);
            }
            else if (typeChoice == "3")
            {
                Console.Write("Enter target count (number of completions needed): ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completing the checklist: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
            }
            else if (typeChoice == "4")
            {
                newGoal = new NegativeGoal(name, description, points);
            }
            else
            {
                Console.WriteLine("Invalid goal type.");
                return;
            }
            goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }

        static void ListGoals()
        {
            Console.WriteLine("\n--- Your Goals ---");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
            }
        }

        static void RecordEvent()
        {
            ListGoals();
            Console.Write("\nSelect the number of the goal you accomplished: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
            {
                int earned = goals[index - 1].RecordEvent();
                if (earned != 0)
                {
                    Console.WriteLine($"You earned {earned} points!");
                    user.AddScore(earned);
                }
                else
                {
                    Console.WriteLine("No points earned (goal may already be completed).");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        static void SaveProgress()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(user.Serialize());
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.Serialize());
                }
            }
            Console.WriteLine("Progress saved successfully!");
        }

        static void LoadProgress()
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No save file found.");
                return;
            }
            string[] lines = File.ReadAllLines("goals.txt");
            if (lines.Length > 0)
            {
                user = User.Deserialize(lines[0]);
                goals = new List<Goal>();
                for (int i = 1; i < lines.Length; i++)
                {
                    goals.Add(Goal.Deserialize(lines[i]));
                }
                Console.WriteLine("Progress loaded successfully!");
            }
        }
    }
}
