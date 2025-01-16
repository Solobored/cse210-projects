using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}~|~{entry.Mood}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split("~|~");
                if (parts.Length == 4)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2], parts[3]));
                }
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    public void AnalyzeMoodTrends()
    {
        var moodCounts = _entries.GroupBy(e => e.Mood)
                                 .Select(g => new { Mood = g.Key, Count = g.Count() })
                                 .OrderByDescending(g => g.Count);

        Console.WriteLine("\nMood Trends:");
        foreach (var mood in moodCounts)
        {
            Console.WriteLine($"{mood.Mood}: {mood.Count} entries");
        }
    }
}