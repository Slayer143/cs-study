using System;

namespace homework__harder_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            while (again == true)
            { 
            Console.WriteLine("Enter two numbers:");
            Console.WriteLine("First");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Second");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Choose the action from given:");
            Console.WriteLine($"0 - addition {firstNumber} of {secondNumber}");
            Console.WriteLine($"1 - subtraction {firstNumber} of {secondNumber}");
            Console.WriteLine($"2 - subtraction {secondNumber} of {firstNumber}");
            Console.WriteLine($"3 - multiplication {firstNumber} of {secondNumber}");
            Console.WriteLine($"4 - division {firstNumber} by {secondNumber}");
            Console.WriteLine($"5 - division {secondNumber} by {firstNumber}");
            Console.WriteLine($"6 - remainder of the division {firstNumber} by {secondNumber}");
            Console.WriteLine($"7 - remainder of the division {secondNumber} by {firstNumber}");
            Console.WriteLine($"8 - exponentiation {firstNumber} to {secondNumber}");
            Console.WriteLine($"9 - exponentiation {secondNumber} to {firstNumber}");
            var numberOfChosenAction = int.Parse(Console.ReadLine());
                if (numberOfChosenAction == 0)
                {
                    Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                }
                else if (numberOfChosenAction == 1)
                {
                    Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                }
                else if (numberOfChosenAction == 2)
                {
                    Console.WriteLine($"{secondNumber} - {firstNumber} = {secondNumber - firstNumber}");
                }
                else if (numberOfChosenAction == 3)
                {
                    Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                }
                else if (numberOfChosenAction == 4)
                {
                    Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                }
                else if (numberOfChosenAction == 5)
                {
                    Console.WriteLine($"{secondNumber} / {firstNumber} = {secondNumber / firstNumber}");
                }
                else if (numberOfChosenAction == 6)
                {
                    Console.WriteLine($"{firstNumber} % {secondNumber} = {firstNumber % secondNumber}");
                }
                else if (numberOfChosenAction == 7)
                {
                    Console.WriteLine($"{secondNumber} % {firstNumber} = {secondNumber % firstNumber}");
                }
                else if (numberOfChosenAction == 8)
                {
                    var i = System.Math.Pow(firstNumber, secondNumber);
                    Console.WriteLine($"{i}");
                }
                else if (numberOfChosenAction == 9)
                {
                    var i = System.Math.Pow(secondNumber, firstNumber);
                    Console.WriteLine($"{i}");
                }
                bool yesOrNot = true;
                while (yesOrNot == true)
                {
                    Console.WriteLine("Do you want to enter another numbers? Press 1 or 0");
                    string pressChecker = Console.ReadLine();
                    if (pressChecker == "1") yesOrNot = false;
                    else if (pressChecker == "0") yesOrNot = again = false;
                    else Console.WriteLine("Incorrect data. Try again");
                }
                if (yesOrNot == true) Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
