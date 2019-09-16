using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_15
{
	class Account<T1,T2> where T1 : struct 
	{
		public T1 Id { get; set; }
		public T2 Name { get; set; }
		public string Properties
		{
			get
			{
				return $"ID: {Id}\n" +
					$"Name: {Name}\n";
			}
		}

		public Account(T1 id, T2 name)
		{
			Id = id;
			Name = name;
			WriteProperties();
		}

		public void WriteProperties()
		{
			Console.WriteLine(Properties);
		}
	}
}
