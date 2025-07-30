using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by listing positive items.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($">>> {_prompts[rand.Next(_prompts.Count)]}");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }
}
