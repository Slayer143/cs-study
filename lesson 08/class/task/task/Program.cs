using System;
using System.Collections.Generic;

namespace task
{
	class Program
	{
		static void Main(string[] args)
		{
			const string exitCommand = "stop";
			string inputString = null;
			List<double> valueList = new List<double>();

			while(inputString != exitCommand)
			{
				Console.WriteLine("Please input value. You can input stop to exit");								
				inputString = Console.ReadLine();

				try
				{
					if (inputString != exitCommand)
					{
						valueList.Add(Convert.ToDouble(inputString));
					}
				}
				catch (Exception e)
				{
					Console.WriteLine("You entered wrong value. Closing the program...");
					throw e;
				}				
			}

			double average = 0;

			foreach (double value in valueList)
			{
				average = average + value;
			}

			Console.WriteLine($"Sum is: {average}\n" +
				$"Average value is: {average / valueList.Count}");
		}
	}
}
