using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Prompt prompt = new Prompt();

        Console.WriteLine("Welcome to the Journal Program!");

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Write a new journal entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string currentPrompt = prompt.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {currentPrompt}");
                    Console.Write("Write your response: ");
                    string response = Console.ReadLine();

                    string date = DateTime.Now.ToShortDateString();
                    Entry entry = new Entry(currentPrompt, response, date);
                    journal.AddEntry(entry);
                    Console.WriteLine("Entry added to the journal.");
                    break;

                case "2":
                    Console.WriteLine("\nYour journal entries:");
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter filename to save to (e.g. journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load from (e.g. journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1-5.");
                    break;
            }
        }
    }
}
