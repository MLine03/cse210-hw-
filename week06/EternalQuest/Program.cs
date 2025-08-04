using System;

namespace EternalQuestApp
{
    class Program
    {
        static void Main()
        {
            GoalManager manager = new GoalManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Progress");
                Console.WriteLine("6. Load Progress");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        RecordEvent(manager);
                        break;
                    case "3":
                        manager.ShowGoals();
                        break;
                    case "4":
                        manager.ShowScore();
                        break;
                    case "5":
                        manager.Save("goals.json");
                        break;
                    case "6":
                        manager.Load("goals.json");
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing Eternal Quest!");
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Select goal type: 1 - Simple, 2 - Eternal, 3 - Checklist");
            string type = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();

            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            Console.Write("Enter points for each event: ");
            if (!int.TryParse(Console.ReadLine(), out int points) || points < 0)
            {
                Console.WriteLine("Invalid points.");
                return;
            }

            switch (type)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(name, desc, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    if (!int.TryParse(Console.ReadLine(), out int target) || target <= 0)
                    {
                        Console.WriteLine("Invalid target count.");
                        return;
                    }
                    Console.Write("Enter bonus points on completion: ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                    {
                        Console.WriteLine("Invalid bonus points.");
                        return;
                    }
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordEvent(GoalManager manager)
        {
            manager.ShowGoals();
            Console.Write("Select goal number to record event: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                manager.RecordGoalEvent(choice - 1);
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
