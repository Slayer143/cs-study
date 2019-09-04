using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_12_task
{
	class Passport : BaseDocument
	{
		public string Country { get; set; }
		public string PersonName { get; set; }

		public override string PropertiesString
		{
			get
			{
				return base.PropertiesString +
					$"Country: {Country}\n" +
					$"Person name: {PersonName}\n";

			}
		}

		public Passport(string docNumber, DateTimeOffset issueDate, string country, string personName) 
			: base("Passport", docNumber, issueDate)
		{
			Country = country;
			PersonName = personName;
		}

		public void ChangeIssueDate(DateTimeOffset newIssueDate)
		{
			IssueDate = newIssueDate;
		}
	}
}
