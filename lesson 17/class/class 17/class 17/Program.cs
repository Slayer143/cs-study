using System;
using System.Threading;

namespace class_17
{
	class Program
	{
		static void Main(string[] args)
		{
			//WorkPerformedEventHandler del1 = WorkPerformed1;
			//WorkPerformedEventHandler del2 = WorkPerformed2;
			//WorkPerformedEventHandler del3 = WorkPerformed3;

			//del1 += del2 + del3;

			//int finalResult = del1(3, workType.Work);
			//Console.WriteLine($"Result is {finalResult}");

			//var worker = new Worker();
			//worker.WorkStarted += OnWorkStarted;
			//worker.WorkPeaceDone += OnWorkPeaceDone;
			//worker.WorkCompleted += OnWorkCompleted;

			//Thread thread1 = new Thread(() =>
			//worker.DoWork(5, workType.Work));

			//Thread thread2 = new Thread(() =>
			//worker.DoWork(3, workType.DoNothing));

			//thread1.Start();
			//thread1.Join();

			//thread2.Start();

			//thread2.Join();

			//Console.WriteLine("Finish!");

			var eWorker = new ExtendedWorker
			{
				RepeatOnFailure = true,
				RepeatCount = 3
			};

			//worker.DoWork(5, workType.Work);
			//worker.DoWork(3, workType.DoNothing);
		}

		private static void OnWorkStarted(int hours, workType workType)
		{
			Console.WriteLine($"Work started: {hours} with {workType} type");
		}

		private static void OnWorkPeaceDone(int hours, workType workType)
		{
			Console.WriteLine($"{hours} of {workType} type done");
		}

		private static void OnWorkCompleted(object sender, EventArgs e)
		{
			Console.WriteLine($"Work completed: {sender}  {e}");
		}

		//private static int WorkPerformed1(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[1] Work type is {workType} performed for {hours} hours");
		//	return 1;
		//}

		//private static int WorkPerformed2(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[2] Work type is {workType} performed for {hours} hours");
		//	return 2;
		//}

		//private static int WorkPerformed3(int hours, WorkType workType)
		//{
		//	Console.WriteLine($"[3] Work type is {workType} performed for {hours} hours");
		//	return 3;
		//}
	}
}
