using System;
using System.Collections.Generic;
using System.Text;

namespace class_17
{
	class ExtendedWorker : Worker
	{
		public bool RepeatOnFailure { get; set; }

		public int RepeatCount { get; set; }

		public override void DoWork(int hours, workType workType)
		{
			if (!RepeatOnFailure)
			{
				base.DoWork(hours, workType);
				return;
			}

			List<Exception> exceptions = new List<Exception>();
			for (int i = RepeatCount; i > 0; i--)
			{
				try
				{


					base.DoWork(hours, workType);
					return;
				}
				catch (Exception exception)
				{
					exceptions.Add(exception);
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}

		protected override void OnWorkPerformed(int hours, workType workType)
		{
			//base.OnWorkPerformed(hours, workType);
		}
	}
}
