using System;

namespace ConsoleApp1
{
    class Program
    {
        [Flags]
        enum WindDirection
        {
            None = 0,
            North = 1,
            East = 1 << 1,
            South = 1 << 2,
            West = 1 << 3
        };
        //enum Day {
        //    Sunday = 10,
        //    Monday,
        //    Tuesday,
        //    Wednesday,
        //    Thursday = 11,
        //    Friday,
        //    Saturday
        //};
        //enum Month : byte
        //{
        //    Jan,
        //    Feb,
        //    Mar,
        //    Apr,
        //    May,
        //    Jun,
        //    Jul,
        //    Aug,
        //    Sep,
        //    Oct,
        //    Nov,
        //    Dec
        //};
        static void Main(string[] args)
        {
            //int a = 18;
            //int b = a++;

            //Console.WriteLine(b == a);
            //Console.WriteLine(b != a);
            //Console.WriteLine(b > a);
            //Console.WriteLine(b < a);
            //Console.WriteLine(b >= a);
            //Console.WriteLine(b <= a);

            //Day today = Day.Monday;
            //int dayNumber = (int)today;
            //Console.WriteLine("{0} is a day number #{1}.", today, dayNumber);

            int a = 113;
            int b = 5;

            int c = a | b;

            Console.WriteLine(ToSixteenString(a)); // вывод в 16-ной системе
            Console.WriteLine(ToBinaryString(a));
            Console.WriteLine(ToBinaryString(b));

            Console.WriteLine(ToBinaryString(a | b));
            Console.WriteLine(ToBinaryString(a & b));
            Console.WriteLine(ToBinaryString(a ^ b));
            Console.WriteLine(ToBinaryString(~a));
            Console.WriteLine(ToBinaryString(~b));

            // shift

            Console.WriteLine();
            Console.WriteLine("Shifts");
            Console.WriteLine();

            int shiftSample = 7;
            Console.WriteLine(ToBinaryString(shiftSample));
            Console.WriteLine(ToBinaryString(shiftSample << 1));

            Console.WriteLine(ToBinaryString(-2147483648));
            Console.WriteLine(ToBinaryString(-2147483648 << 1));
            Console.WriteLine(ToBinaryString(-2147483648 >> 1));

            // enum

            Console.WriteLine();
            Console.WriteLine("Enums");
            Console.WriteLine();

            Console.WriteLine(ToBinaryString((int)WindDirection.None));
            Console.WriteLine(ToBinaryString((int)WindDirection.North));
            Console.WriteLine(ToBinaryString((int)WindDirection.East));
            Console.WriteLine(ToBinaryString((int)WindDirection.South));
            Console.WriteLine(ToBinaryString((int)WindDirection.West));

            WindDirection wd = WindDirection.East | WindDirection.North;
            Console.WriteLine(ToBinaryString((int)wd));
            Console.WriteLine(wd);

            Console.WriteLine(string.Join (" - ", new[] {1, 2, 4, 8 })); // new line " \n "

            string inputWindDirection = Console.ReadLine();
            WindDirection wd2 = (WindDirection)Enum.Parse(typeof(WindDirection), inputWindDirection);
        }

        static string ToSixteenString (int argument)
        {
            return Convert.ToString("0x" + argument.ToString("X").PadLeft(32, '0') + $"({argument} in 16)");
        }

        static string ToBinaryString (int argument)
        {
            return Convert.ToString(argument, 2).PadLeft(32, '0') + $"({argument} in 2)"; // вывод в 2-ной системе
        }
    }
}
