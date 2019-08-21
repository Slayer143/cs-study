using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace class_08
{
	class Program
	{
		static void Main(string[] args)
		{
			//const string fileName = @"test.txt";
			//const string testMessage = "Hello, world";

			//byte[] messageAnsiBytes = Encoding.ASCII.GetBytes(testMessage);

			//FileStream testFileStream = File.Open(
			//	fileName,
			//	FileMode.OpenOrCreate,
			//	FileAccess.Write,
			//	FileShare.Read);

			//testFileStream.Seek(0, SeekOrigin.End);
			//testFileStream.Write(messageAnsiBytes);
			//testFileStream.Flush();
			//testFileStream.Close();


			//FileStream testFileStream2 = File.Open(
			//	fileName,
			//	FileMode.Append,
			//	FileAccess.Write);

			//StreamWriter streamWriter2 = new StreamWriter(testFileStream2, Encoding.ASCII);
			//streamWriter2.Write(Environment.NewLine);
			//streamWriter2.Write(new string(testMessage.Reverse().ToArray()));
			//streamWriter2.Close();
			//testFileStream2.Close();


			//List<int> intList = new List<int>
			//{
			//	10,
			//	20,
			//	30,
			//	40
			//};

			//Console.WriteLine(string.Join(", ", intList));


			//var countries = new Dictionary<string, string>(5)
			//{
			//	{ "1", "Russia" },
			//	{ "2", "Great Britain" },
			//	{ "3", "USA" },
			//	{ "4", "France" },
			//	{ "5", "China" }
			//};

			//foreach (KeyValuePair<string, string> keyValue in countries)
			//	Console.WriteLine($"{keyValue.Key} - {keyValue.Value}");

			//string country = countries["4"];
			//countries["4"] = "Spain";
			//countries.Remove("2");

			//Console.WriteLine("The most interesting country in the world is {0}\n" +
			//	"I visited {0} recently and get a lot of pleasure! Go to {0}!", countries["3"]);


			const string washCommand = "wash";
			const string dryCommand = "dry";
			const string exitCommand = "exit";
			string inputString = null;
			var processStack = new Stack<int>();

			while (inputString != exitCommand)
			{
				Console.WriteLine("Enter command: wash, dry or exit");
				inputString = Console.ReadLine();

				switch (inputString)
				{
					case washCommand:
						processStack.Push(1);
						break;
					case dryCommand:
						if (processStack.Count != 0)
							processStack.Pop();
						else
							Console.WriteLine("Place is empty");
						break;
					case exitCommand:
						Console.WriteLine("End of the game...");
						break;
				}

				Console.WriteLine(processStack.Count);
			}
		}
	}
}
