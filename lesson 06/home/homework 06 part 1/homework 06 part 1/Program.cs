using System;

namespace homework_06_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool incorrectInput = true;
            int counter = 0;

            Console.WriteLine("Please enter natural value less than 2 000 000 000");

            while (incorrectInput)
            {
                try
                {
                    Int32 converter = Int32.Parse(Console.ReadLine());
                    //if (converter > 2_000_000_000 || converter < 0)
                    //{
                    //    System.OverflowException e = new OverflowException();
                    //    throw e;
                    //}

                    string procedureString = Convert.ToString(converter);
                    foreach (int letter in procedureString)
                    {
                        if (letter % 2 == 0)
                        {
                            counter++;
                        }
                    }

                    Console.WriteLine($"Value {converter} contains {counter} even numbers");
                    incorrectInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error {e.GetType()}!\n" +
                        $"Information about error: {e.Message}\n" +
                        "Try again:");
                }
            }
        }
    }
}
