using System;

namespace class_work
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            a = 10;

            int b = 20;

            string name = "Sum of";

            char symbol = '=';

            Console.WriteLine($"{name} {a} + {b} {symbol} {a+b}");

            byte maximumByte = 255;

            sbyte maximumSignedByte = SByte.MaxValue;
            sbyte minimumSignedByte = SByte.MinValue;

            byte age = 36;

            byte ageInHex = 0x24; // 36

            short minimumShort = short.MinValue;
            short maximumShort = short.MaxValue;

            int maximumInt = int.MaxValue;
            int minimumInt = int.MinValue;

            double s = 1.7E+3;

            Console.WriteLine($"[{minimumSignedByte} ... {maximumSignedByte}], {maximumByte}, {ageInHex} = {age}, [{minimumShort}...{maximumShort}], [{minimumInt}...{maximumInt}], {s}");

            int sun = 1_321_123;
            long universe = sun;
            sun = (int)universe;
            float f = sun;
            sun = (int)f;
            string valueOfSun = sun.ToString();
            Console.WriteLine($"{valueOfSun}, {sun}");

            Console.WriteLine("Введите число");
            string value = Console.ReadLine();
            int integerValue = int.Parse(value);
            Console.WriteLine($"{value + value}, {integerValue + integerValue}");
        }
    }
}
