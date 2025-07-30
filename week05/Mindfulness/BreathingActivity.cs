using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int interval = 5;
        int cycles = _duration / (interval * 2);

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("Breathe in...");
            ShowCountdown(interval);

            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountdown(interval);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
