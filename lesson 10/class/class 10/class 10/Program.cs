using System;

class AloneClass
{

	public class SubClass
	{
		public static void PrintFromSubClass()
		{
			Console.WriteLine("Hello from SubClass!");
		}
	}

	public static void PrintWorld()
	{
		Console.WriteLine("World!");
	}
}

namespace class_10
{
	class Program
	{
		static void Main(string[] args)
		{
			AnotherNamespace.MyDemoClass.PrintHello();
			AloneClass.PrintWorld();
			AloneClass.SubClass.PrintFromSubClass();
		}
	}
}

namespace AnotherNamespace
{

	class MyDemoClass
	{

		public static void PrintHello()
		{
			Console.WriteLine("Hello!");
		}
	}
}
