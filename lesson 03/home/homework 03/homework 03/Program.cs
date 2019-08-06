using System;
using System.Threading;

namespace homework_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // program works correctly if sizes of arrays are equal
            const int sizeOfFirstMultiplierArray = 10;
            const int sizeOfSecondMultiplierArray = 10;
            int sizeOfAnswerArray = sizeOfFirstMultiplierArray * sizeOfSecondMultiplierArray;
            int counter = 0;

            // creating arrays
            int[] firstPartOfMultipliers = new int[sizeOfFirstMultiplierArray];
            int[] secondPartOfMultipliers = new int[sizeOfSecondMultiplierArray];
            int[] arrayOfAnswers = new int[sizeOfAnswerArray];

            // adding numbers to the first array
            for (int i = 0; i < sizeOfFirstMultiplierArray; i++)
            {
                Console.WriteLine($"Please input multiplier №{i + 1} to the first table of multipliers");
                firstPartOfMultipliers[i] = int.Parse(Console.ReadLine());               
            }

            // adding numbers to the second array
            for (int i = 0; i < sizeOfSecondMultiplierArray; i++)
            {
                Console.WriteLine($"Please input multiplier №{i + 1} to the second table of multipliers");
                secondPartOfMultipliers[i] = int.Parse(Console.ReadLine());
            }

            // preparing for answer
            Console.Clear();
            Thread.Sleep(3500);
            Console.WriteLine("There is the answer");

            // math calculations
            for (int i = 0; i < sizeOfFirstMultiplierArray; i++)
            {
                for (int a = 0; a < sizeOfSecondMultiplierArray; a++)
                {
                    arrayOfAnswers[counter] = firstPartOfMultipliers[i] * secondPartOfMultipliers[a];
                    counter++;
                }
            }
            counter = 0;

            // print answer
            for (int a = 0; a < sizeOfSecondMultiplierArray; a++)
            {
                for (int i = 0; i < sizeOfFirstMultiplierArray; i++)
                {
                    Console.Write($" { arrayOfAnswers[counter] } ");
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}
