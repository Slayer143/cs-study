using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricFigures
{
	public class Rectangle
	{
		private double _sideA;
		private double _sideB;

		public Rectangle(double sideA, double sideB)
		{
			_sideB = sideB;
			_sideA = sideA;
		}

		public double Calculate(Func<double, double, double> func)
		{
			return func(_sideA, _sideB);
		}
	}
}
