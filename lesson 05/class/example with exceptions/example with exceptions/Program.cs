using System;

namespace example_with_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = RequestIntegerFromConsole("Enter side a");
                int b = RequestIntegerFromConsole("Enter side b");

                Console.WriteLine($"S is {a * b}");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error of program working happened!");
                throw;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Program working stopped without errors");
        }

        static int RequestIntegerFromConsole(
            string requestMessage)
        {
            Console.WriteLine(requestMessage);
            return int.Parse(Console.ReadLine());
        }
    }
}
