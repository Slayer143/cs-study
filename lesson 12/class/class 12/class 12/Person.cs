using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace class_12
{
	public class Person
	{
		public string Name { get; set; }
		public DateTimeOffset DateOfBirth { get; set; }

		public virtual string ShortDescription
		{
			get
			{
				return $"{GetType().Name}\n" +
					$"name: {Name}\n" +
					$"date of birth: {DateOfBirth:dd-MM-yy}\n";
			}
		}

		public Person(string name, DateTimeOffset dateOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
			Debug.WriteLine("Constructor Person(name, dateOfBirth) called.");
		}

		public void WriteShortDescription()
		{
			Console.WriteLine(ShortDescription);
		}
	}
}
