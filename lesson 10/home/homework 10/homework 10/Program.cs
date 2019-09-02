using System;

namespace homework_10
{
	class Program
	{
		static void Main(string[] args)
		{
			const int n = 4;

			Person[] persons = new Person[n];

			for (int i = 0; i < n; i++)
			{
				Person person = new Person();

				Console.WriteLine($"Please enter the name of {i + 1} person");
				person.Name = Convert.ToString(Console.ReadLine());

				Console.WriteLine($"Please enter the age of {i + 1} person");
				person.Age = Convert.ToInt32(Console.ReadLine());

				persons[i] = person;
			}

			foreach (var person in persons)
			{
				person.WriteOutProperties(n);
			}
		}
	}

	class Person
	{
		private string _name;
		private int _age;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;

			}
		}
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				if (value > 0 && value < 140)
				{
					_age = value;
				}
			}
		}

		public int InterestingPeriodInYears { get; set; }

		private int AgeAfterFourYears(int numberOfYears)
		{
			return Age + numberOfYears;
		}
		public string GetOutputInformation(int numberOfYears)
		{
			return $"Name: {Name}, age in 4 years: {AgeAfterFourYears(numberOfYears)}";
		}

		public void WriteOutProperties(int numberOfYears)
		{
			Console.WriteLine(GetOutputInformation(numberOfYears));
		}

		
	}
}
