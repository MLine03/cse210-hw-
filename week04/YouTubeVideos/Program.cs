using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("The Future of AI", "TechWorld", 540);
        v1.AddComment(new Comment("Alice", "Really insightful!"));
        v1.AddComment(new Comment("Bob", "I love this channel."));
        v1.AddComment(new Comment("Cindy", "AI is scary but exciting."));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Top 10 Travel Destinations", "GlobeTrotter", 420);
        v2.AddComment(new Comment("Derek", "Adding these to my bucket list!"));
        v2.AddComment(new Comment("Eliza", "Been to 3 of these, loved them!"));
        v2.AddComment(new Comment("Frank", "Great recommendations."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("How to Bake a Cake", "SweetTooth", 300);
        v3.AddComment(new Comment("Grace", "Mine didn’t rise. Help!"));
        v3.AddComment(new Comment("Henry", "Tastes great!"));
        v3.AddComment(new Comment("Isla", "Yummy recipe, thanks."));
        videos.Add(v3);

        // Display all video info and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
