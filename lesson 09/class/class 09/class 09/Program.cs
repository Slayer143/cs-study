using System;
using System.Diagnostics;

namespace class_09
{
	class Program
	{
		static void Main(string[] args)
		{
			const int length = 100000;
			const int maxValue = int.MaxValue;

			Stopwatch sw = new Stopwatch();

			int[] arr = GetTestArray(length, maxValue);

			//PrintArray(arr, "Initial array:");

			sw.Start();
			var sortedArray = BubbleSort(arr);
			sw.Stop();
			Console.WriteLine($"Bubble sort done in {sw.ElapsedMilliseconds} ms:");

			//PrintArray(sortedArray, "Bubble sorted array:");

			sw.Restart();
			int[] sortedArray2 = SystemSort(arr);
			sw.Stop();
			Console.WriteLine($"System sort done in {sw.ElapsedMilliseconds} ms:");

			//PrintArray(sortedArray2, "System sorted array:");

			//PrintArray(arr, "Initial array (again):");

			//int a = 10;
			//UpdateValue(ref a);
			//Console.WriteLine(a);
		}

		private static int[] SystemSort(int[] arr)
		{
			int[] a = (int[])arr.Clone();
			Array.Sort(a);
			return a;
		}

		//public static void UpdateValue (ref int a)
		//{
		//	a++;
		//	Console.WriteLine(a);
		//}



		public static int[] BubbleSort(int[] inputArray)
		{
			int[] arr = (int[])inputArray.Clone();

			for (var i = 0; i < arr.Length; i++)
			{
				for (var j = 0; j < arr.Length; j++)
				{
					if (arr[i] < arr[j])
					{
						int changer = arr[j];
						arr[j] = arr[i];
						arr[i] = changer;
					}
				}
			}

			return arr;
		}

		public static void PrintArray(int[] arr, string message)
		{
			Console.WriteLine(message);
			Console.WriteLine(string.Join(" , ", arr) + "\n");
		}

		public static int[] GetTestArray(int arrayLength, int maxElementValue)
		{
			var arr = new int[arrayLength];
			var rnd = new Random();

			for (var i = 0; i < arr.Length; i++)
			{
				arr[i] = rnd.Next(maxElementValue);
			}

			return arr;
		}
	}
}
