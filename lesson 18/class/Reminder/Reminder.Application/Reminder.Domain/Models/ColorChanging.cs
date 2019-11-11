using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.Models
{
	public class ColorChanging
	{
		public void WriteRed(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(text);
			Console.ResetColor();
		}

		public void WriteGreen(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(text);
			Console.ResetColor();
		}

		public void WriteOrchid(string text)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(text);
			Console.ResetColor();
		}
	}
}
