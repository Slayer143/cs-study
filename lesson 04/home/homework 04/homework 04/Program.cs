using System;

namespace homework_04
{
    class Program
    {
        [Flags]
        enum Colors
        {
            None = 0,
            Black = 1,
            Blue = 1 << 1,
            Cyan = 1 << 2,
            Grey = 1 << 3,
            Green = 1 << 4,
            Magenta = 1 << 5,
            Red = 1 << 6,
            White = 1 << 7,
            Yellow = 1 << 8
        };
        static void Main(string[] args)
        {
            Colors palette = Colors.Black | Colors.Blue | Colors.Cyan | Colors.Grey | Colors.Green | Colors.Magenta | Colors.Red | Colors.White | Colors.Yellow;

            Console.WriteLine("Please input the given number in order to avoid mistakes. Do not choose 'None' ");
            Console.WriteLine("Choose 4 of your favorite colors from given:");
            foreach (var color in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine($"Number {Convert.ToInt32(color)} is : {color}.");
            }

            Colors favoriteColors = Colors.None;
            for (int i = 0; i < 4; i++)
            {
                string stringOfHelp = Console.ReadLine();
                favoriteColors = favoriteColors | (Colors)Enum.Parse(typeof(Colors), stringOfHelp);
            }

            Console.Clear();

            Console.Write("Your favorite colors are:");
            Console.WriteLine($" {favoriteColors}");

            Console.Write("Your unfavorite colors are:");
            Colors unfavoriteColors = palette ^ favoriteColors;
            Console.WriteLine($" {unfavoriteColors}");
        }
    }
}
