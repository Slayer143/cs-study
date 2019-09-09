using System;
using System.Collections.Generic;
using System.Text;

namespace class_13
{
	class Plane : FlyingObject
	{
		private byte EnginesCount { get; set; }

		public override string AllProperties
		{
			get
			{
				return base.AllProperties +
					$"Engines: {EnginesCount}\n";
			}
		}

		public Plane(int maxHeight, byte enginesCount)
			: base(maxHeight, "plane")
		{
			EnginesCount = enginesCount;
		}
	}
}
