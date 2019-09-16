using System;
using System.Collections.Generic;

namespace lesson_15
{
	class Program
	{
		static void Main(string[] args)
		{
			//int a = 2, b = 5;
			//Console.WriteLine($"{a}, {b}");

			//Swapper<int>.Swap(ref a, ref b);
			//Console.WriteLine($"{a}, {b}");

			//var account1 = new Account<int, string>(1, "One");
			//var account2 = new Account<string, int>("Two", 2);
			//var account3 = new Account<Guid, string>(Guid.NewGuid(), "New guid");

			var l = Swapper<List<string>>.GetDefaultObject();
		}
	}
}
