using System;
using System.Collections.Generic;
using System.Text;

namespace class_13
{
	public abstract class FlyingObject
	{
		private int MaxHeight { get; set; }
		private int CurrentHeight { get; set; }

		public virtual string AllProperties
		{
			get
			{
				return $"Current height: {CurrentHeight}\n" +
					$"Max height: {MaxHeight}\n";
			}
		}

		public FlyingObject(int maxHeight, string objectType)
		{
			MaxHeight = maxHeight;
			CurrentHeight = 0;

			Console.WriteLine($"Is`s a {objectType}, welcome abroad!");
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException("Delta is out of range!");

			if (CurrentHeight + delta > MaxHeight)
				CurrentHeight = MaxHeight;
			else
				CurrentHeight += delta;
		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException("Delta is out of range!");

			if (CurrentHeight - delta > 0)
				CurrentHeight += delta;
			else if (CurrentHeight - delta == 0)
				CurrentHeight = 0;
			else
				throw new InvalidOperationException("Invalid operation!");
		}

		public void WriteAllProperties()
		{
			Console.WriteLine(AllProperties);
		}
	}
}
