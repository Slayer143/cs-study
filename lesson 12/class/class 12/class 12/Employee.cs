using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace class_12
{
	public class Employee : Person
	{
		public string EmployeeCode { get; set; }
		public DateTimeOffset HireDate { get; set; }

		public override string ShortDescription
		{
			get
			{
				return base.ShortDescription +
					$"code: {EmployeeCode}\n" +
					$"hire date: {HireDate:dd-MM-yy}";
			}
		}

		public Employee(string name, DateTimeOffset dateOfBirth) 
			: base(name, dateOfBirth)
		{
			Debug.WriteLine("Constructor Person(name, dateOfBirth) called.");
		}

		public Employee(string name, DateTimeOffset dateOfBirth, string employeeCode, DateTimeOffset hireDate)
			: this(name, dateOfBirth)
		{
			EmployeeCode = employeeCode;
			HireDate = hireDate;
		}
	}
}
