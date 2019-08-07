using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 18;
            int b = a++;

            Console.WriteLine(b == a);
            Console.WriteLine(b != a);
            Console.WriteLine(b > a);
            Console.WriteLine(b < a);
            Console.WriteLine(b >= a);
            Console.WriteLine(b <= a);
        }
    }
}
