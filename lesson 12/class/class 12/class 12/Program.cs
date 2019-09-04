using System;

namespace class_12
{
	class Program
	{
		static void Main(string[] args)
		{
			var person = new Person(
				"Slayer", 
				DateTimeOffset.Parse("2001-05-23"));

			Console.WriteLine(person.ToString());
			person.WriteShortDescription();

			Employee employee1 = new Employee(
				"Nikita", 
				DateTimeOffset.Parse("2000-04-22"),
				"000001",
				DateTimeOffset.Parse("2016-09-04"));

			Object employee2 = new Employee(
				"George",
				DateTimeOffset.Parse("2000-04-22"));

			((Employee)employee2).HireDate = DateTime.Now;

			Console.WriteLine(employee1.ToString());
			((Person)employee1).WriteShortDescription();

			((Person)employee2).WriteShortDescription();
		}
	}
}
