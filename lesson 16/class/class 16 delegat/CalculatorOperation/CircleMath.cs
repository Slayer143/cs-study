using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorOperation
{
	public class CircleMath
	{
		public static double Perimeter(double radius)
		{
			return radius * (Math.PI * 2);
		}

		public static double Square(double radius)
		{
			return Math.Pow(radius, 2) * (Math.PI);
		}
	}
}
