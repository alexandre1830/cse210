using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            Running run = new Running("03 Nov 2022", 30, 3.0);
            activities.Add(run);

            Cycling cycle = new Cycling("04 Nov 2022", 30, 15.0);
            activities.Add(cycle);

            Swimming swim = new Swimming("05 Nov 2022", 30, 20);
            activities.Add(swim);

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}