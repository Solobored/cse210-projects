using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        int sum = 0;
        int max = int.MinValue;

        foreach (int number in numbers)
        {
            sum += number; 
            if (number > max)
            {
                max = number;
            }
        }

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        if (smallestPositive == int.MaxValue)
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] > numbers[j])
                {
                
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}