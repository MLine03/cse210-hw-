using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void Run() { }

    private string GetRandomPrompt() { return ""; }

    private void DisplayQuestions() { }
}
