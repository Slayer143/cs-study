using System;
using System.Threading;
using System.Text;

namespace firstlesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Thread.Sleep(5000);
            Console.WriteLine($"Здравствуйте, {name}");
            Thread.Sleep(5000);
            Console.WriteLine($"До свидания, {name}");
            Console.ReadKey();
        }
    }
}
