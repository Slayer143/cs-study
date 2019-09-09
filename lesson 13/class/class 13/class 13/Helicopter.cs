using System;
using System.Collections.Generic;
using System.Text;

namespace class_13
{
	class Helicopter : FlyingObject
	{
		private byte BladesCount { get; set; }

		public override string AllProperties
		{
			get
			{
				return base.AllProperties +
					$"Blades: {BladesCount}\n";
			}
		}

		public Helicopter(int maxHeight, byte bladesCount)
			: base(maxHeight, "helicopter")
		{
			BladesCount = bladesCount;
		}
	}
}
