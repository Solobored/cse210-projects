using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(); 
        bool playAgain = true; 

        while (playAgain)
        {
            int magicNumber = random.Next(1, 101); 
            int guess = 0; 
            int attempts = 0; 

            Console.WriteLine("Welcome to the Guess My Number game!");


            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();


                if (int.TryParse(input, out guess))
                {
                    attempts++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it! The magic number was {magicNumber}.");
                        Console.WriteLine($"It took you {attempts} attempts to guess correctly.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            if (response != "yes" && response != "y")
            {
                playAgain = false; 
                Console.WriteLine("Thanks for playing! Goodbye!");
            }
        }
    }
}