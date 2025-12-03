using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private List<int> _usedQuestionIndices;

        public ReflectionActivity()
        {
            _name = "Reflection Activity";
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            _usedQuestionIndices = new List<int>();
        }

        public void Run()
        {
            DisplayStartingMessage();

            DisplayPrompt();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                DisplayQuestion();
            }

            DisplayEndingMessage();
        }

        private void DisplayPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($" --- {_prompts[index]} ---");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            Console.Clear();
        }

        private void DisplayQuestion()
        {
            string question = GetUniqueRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }

        private string GetUniqueRandomQuestion()
        {
            if (_usedQuestionIndices.Count == _questions.Count)
            {
                _usedQuestionIndices.Clear();
            }

            Random random = new Random();
            int index;

            do
            {
                index = random.Next(_questions.Count);
            } while (_usedQuestionIndices.Contains(index));

            _usedQuestionIndices.Add(index);
            return _questions[index];
        }
    }
}