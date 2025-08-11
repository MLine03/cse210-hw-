using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2022, 11, 3), 30, 4.8),
                new Cycling(new DateTime(2022, 11, 3), 45, 20.1),
                new Swimming(new DateTime(2022, 11, 3), 40, 30)
            };

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
