using System;

namespace homework_04
{
    class Program
    {
        [Flags]
        enum colors
        {
            Black = 0,
            Blue = 1,
            Cyan = 1 << 1,
            Grey = 1 << 2,
            Green = 1 << 3,
            Magenta = 1 << 4,
            Red = 1 << 5,
            White = 1 << 6,
            Yellow = 1 << 7
        };
        static void Main(string[] args)
        {
            colors[] favorite = new colors[4];
            colors palette = colors.Black | colors.Blue | colors.Cyan | colors.Grey | colors.Green | colors.Magenta | colors.Red | colors.White | colors.Yellow;

            Console.WriteLine("Please input the given number in order to avoid mistakes");
            Console.WriteLine("Choose 4 of your favorite colors from given:");
            foreach (var color in Enum.GetValues(typeof(colors)))
            {
                Console.WriteLine($"Number {Convert.ToInt32(color)} is : {color}.");
            }

            for (int i = 0; i < 4; i++)
            {
                string stringOfHelp = Console.ReadLine();
                favorite[i] = (colors)Enum.Parse(typeof(colors), stringOfHelp);
            }

            Console.Clear();

            Console.Write("Your favorite colors are:");
            Console.WriteLine($" {favorite[0]}, {favorite[1]}, {favorite[2]}, {favorite[3]}");

            Console.Write("Your unfavorite colors are:");
            colors unfavorite = palette ^ (favorite[0] | favorite[1] | favorite[2] | favorite[3]);
            Console.WriteLine($" {unfavorite}");
        }
    }
}
