using System;

namespace class_10_task
{
	class Program
	{
		static void Main(string[] args)
		{
			var pet1 = new Pet();
			pet1.PetKind = Pet.Kind.Dog;
			pet1.Age = 1;
			pet1.Name = "Jonh";
			pet1.Sex = 'M';
			pet1.SetBirthPlace("London");


			Console.WriteLine(pet1.Description);

			var pet2 = new Pet()
			{
				PetKind = Pet.Kind.Cat,
				Age = 5,
				Name = "Julie",
				Sex = 'F',
			};
			pet2.SetBirthPlace("Krit");

			Console.WriteLine(pet2.Description);
		}
	}

	class Pet
	{
		public enum Kind
		{
			Mouse,
			Cat,
			Dog
		};

		public Kind PetKind;
		private string _birthPlace;
		public string Name;
		private char _sex;

		public char Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				if (char.ToLowerInvariant(value).Equals('f') || char.ToLowerInvariant(value).Equals('m'))
					_sex = char.ToUpperInvariant(value);
				else throw new Exception("Wrong data");
			}
		}
		public int Age { get; set; }
		public string Description
		{
			get
			{
				return $"{Name} is a {PetKind} ({_sex}) of {Age} years old from {_birthPlace}";
			}
		}

		public void SetBirthPlace(string place)
		{
			_birthPlace = place;
		}
	}
}
