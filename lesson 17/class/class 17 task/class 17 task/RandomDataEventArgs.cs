using System;
using System.Collections.Generic;
using System.Text;

namespace class_17_task
{
	public class RandomDataEventArgs : EventArgs
	{
		public int BytesDone { get; set; }
		public int TotalBytes { get; set; }

	}
}
