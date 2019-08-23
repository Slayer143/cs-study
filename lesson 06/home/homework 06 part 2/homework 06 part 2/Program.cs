using System;

namespace homework_06_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double process, desiredAmount, downAmount = 0;
            int daysCounter = 1;
            double percent = 0;

            try
            {
                Console.WriteLine("Enter down payment amount");
                downAmount = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter percentage of income (1% = 0.01)");
                percent = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter desired amount of accumulation");
                desiredAmount = Convert.ToDouble(Console.ReadLine());

                process = downAmount + downAmount * percent;

                while (process < desiredAmount)
                {
                    process = process + process * percent;
                    daysCounter++;
                }

                Console.WriteLine($"Desired amount of accumulation {desiredAmount} will be achieved after {daysCounter} days.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
