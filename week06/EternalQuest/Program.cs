using System;
using System.Collections.Generic;
using System.IO;
// creativity: It has a game like scoring and progression we all like gettin higher scores. 

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalScore = 0;
        const string saveFile = "goals.txt";

        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Eternal Quest Program ===");
                Console.WriteLine($"Total Score: {totalScore}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event (Progress a Goal)");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        DisplayGoals();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter point value (or points per event for eternal/checklist): ");
            int pts = int.Parse(Console.ReadLine());

            Goal newGoal = null;
            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, pts);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, pts);
                    break;
                case "3":
                    Console.Write("Enter target number of completions: ");
                    int target = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, pts, target);
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    return;
            }
            goals.Add(newGoal);
            Console.WriteLine("Goal created successfully. Press Enter to continue.");
            Console.ReadLine();
        }

        static void RecordEvent()
        {
            Console.Clear();
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Press Enter to return.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetDescription()}");
            }
            Console.Write("Choice: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= goals.Count)
            {
                Console.WriteLine("Invalid selection. Press Enter.");
                Console.ReadLine();
                return;
            }
            
            int pointsEarned = goals[index].RecordEvent();
            totalScore += pointsEarned;
            
            Console.WriteLine($"Recorded event. Points earned: {pointsEarned}. Press Enter.");
            Console.ReadLine();
        }


        static void DisplayGoals()
        {
            Console.Clear();
            if (goals.Count == 0)
                Console.WriteLine("No goals to display.");
            else
            {
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal.GetDescription());
                }
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        static void SaveGoals()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(saveFile))
                {
                    writer.WriteLine(totalScore);
                    foreach (var goal in goals)
                    {
                        writer.WriteLine(goal.Serialize());
                    }
                }
                Console.WriteLine("Goals saved successfully. Press Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving goals: " + ex.Message);
            }
            Console.ReadLine();
        }

        static void LoadGoals()
        {
            try
            {
                if (!File.Exists(saveFile))
                {
                    Console.WriteLine("No save file found. Press Enter.");
                    Console.ReadLine();
                    return;
                }
                string[] lines = File.ReadAllLines(saveFile);
                totalScore = int.Parse(lines[0]);
                goals.Clear();
                for (int i = 1; i < lines.Length; i++)
                {
                    Goal g = Goal.Deserialize(lines[i]);
                    goals.Add(g);
                }
                Console.WriteLine("Goals loaded successfully. Press Enter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
