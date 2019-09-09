using System;

namespace class_13
{
	class Program
	{
		static void Main(string[] args)
		{
			Helicopter helicopter = new Helicopter(500, 4);
			helicopter.WriteAllProperties();

			helicopter.TakeUpper(450);
			helicopter.WriteAllProperties();

			Plane plane = new Plane(1000, 8);
			plane.WriteAllProperties();

			plane.TakeUpper(800);
			plane.WriteAllProperties();
		}
	}
}
