using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his only begotten Son";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words hidden. Exiting program.");
                break;
            }
        }
    }
}
