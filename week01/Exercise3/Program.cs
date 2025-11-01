using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        Console.Write("Guess a number between 1 and 100 (enter an integer): ");
        int guess = int.Parse(Console.ReadLine());

        while (guess != number)
        {
            if (guess < number)
            {
                Console.Write("Guess a higher number: ");
            }
            else if (guess > number)
            {
                Console.Write("Guess a lower number: ");
            }
            guess = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Congratulations! You guessed the correct number.");
    }
}