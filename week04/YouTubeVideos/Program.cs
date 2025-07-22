using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            Console.WriteLine($" - {comment.Name}: {comment.Text}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Bake Bread", "Chef Emily", 600);
        video1.AddComment(new Comment("Alice", "This helped me so much!"));
        video1.AddComment(new Comment("Bob", "My bread turned out amazing."));
        video1.AddComment(new Comment("Charlie", "I love your channel."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("DIY Woodworking Table", "HandyDan", 900);
        video2.AddComment(new Comment("Dave", "Great step-by-step tutorial."));
        video2.AddComment(new Comment("Eve", "Mine came out wobbly... any tips?"));
        video2.AddComment(new Comment("Frank", "Subscribed!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Top 10 Coding Tips", "CodeMaster", 450);
        video3.AddComment(new Comment("Grace", "Clear and useful."));
        video3.AddComment(new Comment("Heidi", "Loved the Python tips."));
        video3.AddComment(new Comment("Ivan", "Do one for C# next?"));
        videos.Add(video3);

        // Display all video info
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
