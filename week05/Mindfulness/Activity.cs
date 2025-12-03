using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Mindfulness
{
    public class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity()
        {
            _name = "";
            _description = "";
            _duration = 0;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            
            Console.Write("How long, in seconds, would you like for your session? ");
            if (!int.TryParse(Console.ReadLine(), out _duration))
            {
                _duration = 30;
            }

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(5);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(5);
            
            LogActivity();
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);
            
            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");

                i++;
                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b"); 
                if(i >= 10) Console.Write("\b \b");
            }
        }

        private void LogActivity()
        {
            string path = "activity_log.txt";
            string logEntry = $"{DateTime.Now}: Completed {_name} for {_duration} seconds.";
            
            try 
            {
                File.AppendAllText(path, logEntry + Environment.NewLine);
            }
            catch (Exception)
            {
            }
        }
    }
}