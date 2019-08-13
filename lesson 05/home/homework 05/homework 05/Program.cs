using System;

namespace homework_05
{
    class Program
    {
        enum Figures
        {
            Circle = 1,
            Triangle = 1 << 1,
            Rectangle = 1 << 2
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose one of given figures to work with it:");

            foreach (var figure in Enum.GetValues(typeof(Figures)))
            {
                Console.WriteLine($"{figure} : {Convert.ToInt32(figure)}");
            }

            Figures chosenFigure = (Figures)Enum.Parse(typeof(Figures), Console.ReadLine());
            try
            {                
                if (
                    (Convert.ToInt32(chosenFigure) == Convert.ToInt32(Figures.Circle))
                    | (Convert.ToInt32(chosenFigure) == Convert.ToInt32(Figures.Rectangle))
                    | (Convert.ToInt32(chosenFigure) == Convert.ToInt32(Figures.Triangle)))
                {
                    Console.WriteLine(chosenFigure);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new Exception("You entered wrong values!");
                }

            switch(chosenFigure)
            {
                case Figures.Circle:
                    Console.WriteLine("Please enter diameter:");
                    double diameterOfCircle = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Square is {Math.Round(Math.Pow(diameterOfCircle / 2 , 2) * Math.PI , 1)}");
                    Console.WriteLine($"Perimeter is {Math.Round(Math.PI * 2 * (diameterOfCircle / 2) , 1)}");
                    break;
                case Figures.Triangle:
                    Console.WriteLine("Please enter side length:");
                        double sideOfTriangle = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Square is {Math.Round((Math.Pow(sideOfTriangle, 2) * Math.Sqrt(3)) / 4, 1)}");
                        Console.WriteLine($"Perimeter is {Math.Round(sideOfTriangle * 3, 1)}");
                        break;
                    case Figures.Rectangle:
                        Console.WriteLine("Please enter width:");
                        double widthOfRectangle = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter height:");
                        double heightOfRectangle = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Square is {Math.Round(widthOfRectangle * heightOfRectangle, 1)}");
                        Console.WriteLine($"Perimeter is {Math.Round((2 * widthOfRectangle + heightOfRectangle) , 1)}");
                        break;
            }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new Exception("You entered wrong values!");
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Program finished correctly");
        }
    }
}
