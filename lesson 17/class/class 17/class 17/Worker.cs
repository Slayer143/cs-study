using System;
using System.Collections.Generic;
using System.Text;

namespace class_17
{
	public delegate void WorkStartedEventHandler(int hours, workType workType);

	class Worker
	{
		public event WorkStartedEventHandler WorkStarted;

		public event WorkStartedEventHandler WorkPeaceDone;

		public event EventHandler WorkCompleted;

		public virtual void DoWork(int hours, workType workType)
		{
			WorkStarted?.Invoke(hours, workType);

			for (int i = 0; i < hours; i++)
			{
				System.Threading.Thread.Sleep(500);
				OnWorkPerformed(i + 1, workType);
			}
			WorkCompleted?.Invoke(this, EventArgs.Empty);
		}

		protected virtual void OnWorkPerformed(int hours, workType workType)
		{
			WorkPeaceDone?.Invoke(hours, workType);
		}
	}
}
