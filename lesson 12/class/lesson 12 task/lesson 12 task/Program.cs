using System;

namespace lesson_12_task
{
	class Program
	{
		static void Main(string[] args)
		{
			var first = new BaseDocument(
				"Base",
				"0001",
				DateTimeOffset.Parse("2019-9-4"));

			Console.WriteLine(first.ToString());
			first.WriteToConsole();

			var second = new Passport(
				"0010",
				DateTimeOffset.Parse("2019-8-3"),
				"Canada",
				"John");

			Console.WriteLine(second.ToString());
			second.WriteToConsole();

		}
	}
}
