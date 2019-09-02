using System;

namespace Lesson_11BonusClass
{

	public class Pet
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


		public DateTimeOffset DateOfBirth { get; set; }
		public int Age
		{
			get
			{
				TimeSpan time = DateTimeOffset.Now - DateOfBirth;
				return Convert.ToInt32(Math.Floor(time.Days / 365.242));
			}
		}

		public string ShortDescription
		{
			get { return $"{Name} is a {PetKind}"; }
		}

		public string Description
		{
			get
			{
				return $"{Name} is a {PetKind} ({_sex}) of {Age} years old from {_birthPlace}";
			}
		}

		public Pet(Kind kind)
		{
			PetKind = kind;
		}

		public Pet(Kind kind, DateTimeOffset dateOfBirth) : this(kind)
		{
			DateOfBirth = dateOfBirth;
		}

		public Pet ()
		{

		}

		public void SetBirthPlace(string place)
		{
			_birthPlace = place;
		}

		public void WriteOutDescription(bool isShortDescription = false)
		{			
			if (isShortDescription)
				Console.WriteLine(ShortDescription);
			else
				Console.WriteLine(Description);

			/*
			 * Console.WriteLine(isShortDescription ? ShortDescription : Description);
			 */
		}

		public void UpdateProperties(string name, char sex)
		{
			Name = name;
			Sex = sex;
		}

		public void UpdateProperties(string name, Kind kind)
		{
			Name = name;
			PetKind = kind;
		}

		public void UpdateProperties(string name, char sex, Kind kind)
		{
			Name = name;
			Sex = sex;
			PetKind = kind;
		}


	}
}