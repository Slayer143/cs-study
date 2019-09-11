using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace class_14
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		private List<String> _errors;

		public string Category { get; }

		public static string OutputPrefixFormat { get; set; }

		static ErrorList()
		{
			OutputPrefixFormat = "f";
		}

		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}

		public void Dispose()
		{
			_errors.Clear();
			_errors = null;
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _errors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(string errorMessage)
		{
			_errors.Add(errorMessage);
		}

		public void WriteToConsole()
		{
			foreach (var error in _errors)
				Console.WriteLine(DateTime.Now.ToString(OutputPrefixFormat) + $" Category: {Category}; ERROR: {error.ToUpperInvariant()}");
		}

		//public void WriteOutErrors()
		//{
		//	foreach (var error in Errors)
		//	Console.WriteLine($"Category: {Category}; ERROR: {error.ToUpperInvariant()}");
		//}
	}
}
