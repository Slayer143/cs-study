using System;

namespace class_work_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter h");
            double h = Convert.ToDouble(Console.ReadLine());
            double sSide = Math.Round(3 * a * h);
            Console.WriteLine(sSide);
            double sFull = Math.Round(3 * a / 2 * (3 * Math.Sqrt(a) * h));
            Console.WriteLine(sFull);
        }
    }
}
