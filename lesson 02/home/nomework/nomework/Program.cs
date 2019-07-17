using System;

namespace nomework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два числа");
            Console.WriteLine("Ввод первого числа:");
            int firstNumber = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Ввод второго числа:");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.WriteLine($"умножение: {firstNumber * secondNumber}, сложение: {firstNumber + secondNumber}");
        } 
    }
}
