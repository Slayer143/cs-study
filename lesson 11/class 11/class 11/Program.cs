using System;
using Lesson_11BonusClass;

namespace class_11
{
	class Program
	{
		static void Main(string[] args)
		{
			var pet1 = new Pet();
			pet1.DateOfBirth = DateTimeOffset.Parse("2011-03-14");
			pet1.UpdateProperties("John", Pet.Kind.Dog);
			pet1.SetBirthPlace("London");

			pet1.WriteOutDescription(true);


			var pet2 = new Pet()			
			{
				DateOfBirth = DateTimeOffset.Parse("2014-03-16"),
			};
			pet2.UpdateProperties("Sarah", 'F', Pet.Kind.Cat);
			pet2.SetBirthPlace("Krit");

			pet2.WriteOutDescription(false);
			
		}
	}
}

