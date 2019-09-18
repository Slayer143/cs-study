using System;
using GeometricFigures;
using CalculatorOperation;
using Newtonsoft.Json;

namespace class_16_delegat
{
	class Program
	{
		//delegate int DocCalculation(int a, int b);

		static void Main(string[] args)
		{
			//var calc = new SimpleCalculator();

			//DocCalculation doCalc1 = (x, y) => x + y;
			//DocCalculation doCalc2 = (x, y) => x * y;
			//DocCalculation doCalc3 = (x, y) => x + y;

			//doCalc3 += doCalc1;
			//Console.WriteLine(doCalc3(5, 10));

			//doCalc1 = (DocCalculation)Delegate.Combine(doCalc1, doCalc2);
			//Console.WriteLine(doCalc1(5, 10));

			//doCalc3 -= doCalc1;
			//Console.WriteLine(doCalc3(5, 10));

			//doCalc1 = (DocCalculation)Delegate.Remove(doCalc1, doCalc2);
			//Console.WriteLine(doCalc1(5, 10));

			//Circle circle = new Circle(1.5);

			//Console.WriteLine("For the circle with radius 1.5:");
			//Console.WriteLine($"Perimeter is: {circle.Calculate(x => x * (Math.PI * 2))}");
			//Console.WriteLine($"Square is: {circle.Calculate(x => Math.Pow(x, 2) * (Math.PI))}");

			//var rectangle = new Rectangle(1.5, 2);

			//Console.WriteLine("For the rectangle with side a = 1.5 and side b = 2:");
			//Console.WriteLine($"Perimeter is: {rectangle.Calculate((x, y) => 2 * (x + y))}");
			//Console.WriteLine($"Square is: {rectangle.Calculate((x, y) => x * y)}");

			var jsonData = JsonConvert.SerializeObject(
				new
				{
					Name = "Slayer",
					Age = "29",
					Gender = "Male",
					IsActive = true
				});
			Console.WriteLine(jsonData);
		}
	}
}
