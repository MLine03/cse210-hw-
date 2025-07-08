using System;
using System.Collections.Generic;

/// <summary>
/// Handles the prompt logic for the journal.
/// </summary>
public class Prompt
{
    private static readonly Random _random = new Random();
    private List<string> _prompts;

    /// <summary>
    /// Initializes the list of predefined prompts.
    /// </summary>
    public Prompt()
    {
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    /// <summary>
    /// Returns a randomly selected prompt from the list.
    /// </summary>
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    /// <summary>
    /// Displays all available prompts to the user.
    /// </summary>
    public void ShowAllPrompts()
    {
        Console.WriteLine("Available Prompts:");
        foreach (string prompt in _prompts)
        {
            Console.WriteLine($"- {prompt}");
        }
    }
}
