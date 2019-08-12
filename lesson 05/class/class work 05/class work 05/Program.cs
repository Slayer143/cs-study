using System;

namespace class_work_05
{
    class Program
    {
        enum Color
        {
            Red,
            Green,
            Blue
        }
        static void Main(string[] args)
        {
            ////example with checking for digit, letter or punctuation mark

            //Console.WriteLine("Press any key");
            //char c = Console.ReadKey(true).KeyChar;
            //if (char.IsLetterOrDigit(c))
            //{
            //    Console.WriteLine("You entered a letter or a digit");
            //    if (char.IsUpper(c) & char.IsLetter(c))
            //    {
            //        Console.WriteLine("You entered an upper letter!");
            //    }
            //    else if (char.IsLower(c) & char.IsLetter(c))
            //    {
            //        Console.WriteLine("You entered a lower letter!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("You entered a number!");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"You entered a punctuation mark {c} ");
            //}

            //Console.WriteLine("Press any key to exit...");


            ////example with years from 1 to 100

            //Console.WriteLine("Please enter number from 1 to 100");
            //string years = Console.ReadLine();

            //if (years.EndsWith('1') & years != "11")
            //{

            //    Console.WriteLine($"{years} год");
            //}
            //else if ((years.EndsWith('2') | years.EndsWith('3') | years.EndsWith('4')) & ((years != "12") & (years != "13") & (years != "14")))
            //{
            //    Console.WriteLine($"{years} года");
            //}
            //else if (int.Parse(years) <= 0 | int.Parse(years) >= 100)
            //{
            //    Console.WriteLine("Incorrect number");
            //}
            //else
            //{
            //    Console.WriteLine($"{years} лет");
            //}


            ////example with numbers less or more than 50

            //Console.WriteLine("Enter number from 1 to 100");

            ////example no. 1
            //string inputString = Console.ReadLine();
            //int number = -1;

            //try
            //{
            //    number = int.Parse(inputString);
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"Error of type {e.GetType()}\n" +
            //        $"'{e.Message}' \n" +
            //        $"Default value {number} will be used");
            //}
            //finally
            //{
            //    number++;
            //    Console.WriteLine($"We are in finally block, value is {number}");
            //}
            //if (number <= 100 || number >= 0)
            //{
            //    bool output = Convert.ToInt32(number) > 50 & Convert.ToInt32(number) <= 100;
            //    Console.WriteLine(output ? $"{number} more than 50" : $"{number} less than 50");
            //}
            //else throw new ArgumentOutOfRangeException("Value is more than 100");

            //example no.2 (with example of exception)
            //int inputNumber = int.Parse(Console.ReadLine());

            //if (inputNumber > 100 || inputNumber < 1)
            //{
            //    throw new ArgumentOutOfRangeException($"{inputNumber} is not in the range");
            //}
            //Console.WriteLine(inputNumber > 50 ? $"{inputNumber} more than 50" : $"{inputNumber} less than 50");


            ////example with switch 

            //Color c = (Color)(new Random()).Next(0, 4);
            //switch (c)
            //{
            //    case Color.Red:
            //        Console.WriteLine("The color is red");
            //        break;
            //    case Color.Green:
            //        Console.WriteLine("The color is green");
            //        break;
            //    case Color.Blue:
            //        Console.WriteLine("The color is blue");
            //        break;
            //    default:
            //        Console.WriteLine($"Color is unknown");
            //        break;
            //}

            /* in switch it is possible to write
             * case Color.Red:
             * case Color.Green:
             * Console.WriteLine(The color is red or green);
             * break;
             * it means the operator works if c is Color.Red OR (|) Color.Green
             */


            //// example with exceptions

            //Console.WriteLine("Enter a number less than 100");
            //string strNum = Console.ReadLine();
            //int num = int.Parse(strNum);

            //if (num >= 100)
            //{
            //    throwing new exception according to our logic
            //    throw new Exception("The value should be less than 100!");
            //}

            //Console.WriteLine($"You entered correct value {num}");
            //Console.ReadKey(true);
        }
    }
}
