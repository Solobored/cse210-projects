using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are some of your personal strengths?",
        "Who are people that you have helped recently?",
        "When have you felt particularly inspired?"
    };

    public ListingActivity()
    {
        _activityName = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many items as you can in a given area.";
    }

    public override void Execute()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have a few seconds to think... Get ready!");
        ShowAnimation(3);

        List<string> responses = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        Console.WriteLine("Start listing your items (press Enter after each).");
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string response = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(response))
                    responses.Add(response);
            }
        }
        Console.WriteLine($"You listed {responses.Count} items.");
    }
}
