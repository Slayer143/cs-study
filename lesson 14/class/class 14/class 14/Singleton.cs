using System;
using System.Collections.Generic;
using System.Text;

namespace class_14
{
	class Singleton
	{
		private static Singleton _singleton;

		public int Age { get; set; }

		public string Name { get; set; }

		private Singleton() { }

		public static Singleton GetInstance()
		{
			if (_singleton == null)
				_singleton = new Singleton();

			return _singleton;
		}
	}
}
