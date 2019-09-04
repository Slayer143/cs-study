using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_12_task
{
	class BaseDocument
	{
		public string DocName { get; set; }
		public string DocNumber { get; set; }
		public DateTimeOffset IssueDate { get; set; }

		public virtual string PropertiesString
		{
			get
			{
				return $"Document name: {DocName}\n" +
						$"Document number: {DocNumber}\n" +
						$"Issue date: {IssueDate:dd-MM-yy}\n";
			}
		}

		public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
		{
			DocName = docName;
			DocNumber = docNumber;
			IssueDate = issueDate;
		}

		public void WriteToConsole()
		{
			Console.WriteLine(PropertiesString);
		}
	}
}
