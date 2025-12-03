using System;

// Exceeding Requirements:
// 1. I implemented a system in ReflectionActivity to ensure that random questions are not repeated until all have been shown.
// 2. I added a 'LogActivity' method in the base class that saves a record of every completed activity to 'activity_log.txt'.

namespace Mindfulness
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflection activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                if (choice == "4")
                {
                    break;
                }

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        System.Threading.Thread.Sleep(2000);
                        continue;
                }

                if (activity is BreathingActivity ba) ba.Run();
                else if (activity is ReflectionActivity ra) ra.Run();
                else if (activity is ListingActivity la) la.Run();
            }
        }
    }
}