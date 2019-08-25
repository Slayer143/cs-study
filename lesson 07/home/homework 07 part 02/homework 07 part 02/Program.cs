using System;

namespace homework_07_part_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool process = true;
            string inputString = null;

            while (process)
            {
                Console.WriteLine("Enter a non-empty string");
                try
                {
                    inputString = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(inputString) == true | string.IsNullOrEmpty(inputString) == true)
                    {
                        Console.WriteLine("You can not input empty string!");
                    }

                    else process = false;
                }
                catch
                {

                }
            }

            char[] reverseArray = inputString.ToLowerInvariant().ToCharArray();
            Array.Reverse(reverseArray);
            string outputString = new string(reverseArray);

            Console.WriteLine(outputString);
        }
    }
}
