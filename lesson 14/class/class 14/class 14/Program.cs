using System;

namespace class_14
{
	class Program
	{
		static void Main(string[] args)
		{
			//using (var errorList = new ErrorList("Server errors"))
			//{
			//	errorList.Add("Bad gateway");
			//	errorList.Add("No connetction");

			//	errorList.WriteToConsole();
			//}

			Singleton singleton = Singleton.GetInstance();
			singleton.Name = "Slayer";

			Singleton singleton1 = Singleton.GetInstance();
			singleton1.Age = 20;

			Console.WriteLine(singleton.Age);
			Console.WriteLine(singleton1.Name);
		}
	}
}
