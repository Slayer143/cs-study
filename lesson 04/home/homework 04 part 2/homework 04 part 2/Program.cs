using System;

namespace homework_04_part_2
{
    class Program
    {
        enum Containers
        {
            none = 0,
            oneLitter = 1,
            fiveLitters = 1 << 1,
            twentyLitters = 1 << 2
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter litters of juice you want to wrap up");
            double amount = Double.Parse(Console.ReadLine());

            int firstTypeOfContainers = Convert.ToInt32(Math.Round(amount / 20));
            int secondTypeOfContainers = Convert.ToInt32(Math.Round((amount - firstTypeOfContainers * 20) / 5));
            int thirdTypeOfContainers = Convert.ToInt32(Math.Round((amount - (firstTypeOfContainers * 20 + secondTypeOfContainers * 5)) / 1));
            
            if (firstTypeOfContainers > 0)
            {
                Console.WriteLine($"20 L: {firstTypeOfContainers}");
            }

            if (secondTypeOfContainers > 0)
            {
                Console.WriteLine($"5 L: {secondTypeOfContainers}");
            }

            if (thirdTypeOfContainers > 0)
            {
                Console.WriteLine($"1 L: {thirdTypeOfContainers}");
            }

            Console.WriteLine("\nDebug info:");

            foreach (var container in Enum.GetValues(typeof(Containers)))
            {
                Console.WriteLine(Convert.ToString(Convert.ToInt32(container), 2).PadLeft(32, '0') + $"({container})");
            }
        }
    }
}
