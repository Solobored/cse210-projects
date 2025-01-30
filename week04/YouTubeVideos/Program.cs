using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Tutorial", "Bro Code", 700);
        video1.AddComment(new Comment("Josh", "Great tutorial!"));
        video1.AddComment(new Comment("John", "Very helpful, thanks!"));
        video1.AddComment(new Comment("James", "I learned a lot."));

        Video video2 = new Video("Python Full Course", "Code Academy", 800);
        video2.AddComment(new Comment("Dave", "Clear explanation."));
        video2.AddComment(new Comment("Dan", "Could you cover middleware next?"));
        video2.AddComment(new Comment("Darwin", "Loved the examples."));

        Video video3 = new Video("AI Development", "Coursera", 900);
        video3.AddComment(new Comment("Grace", "Awesome content!"));
        video3.AddComment(new Comment("Gandi", "Looking forward to part 2."));
        video3.AddComment(new Comment("Guy", "Very detailed walkthrough."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayInformation();
        }
    }
}