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
                Console.WriteLine(person.OutputInformation);
            }
        }
    }

    class Person
    {
        public string _name;
        public int _age;

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
        public int AgeAfterFourYears
        {
            get
            {
                return Age += 4;
            }
        }
        public string OutputInformation
        {
            get
            {
                return $"Name: {Name}, age in 4 years: {AgeAfterFourYears}";
            }
        }

    }
}
