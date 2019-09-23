using System;
using System.IO;
using System.IO.Compression;

namespace class_17_task
{
	class Program
	{
		static void Main(string[] args)
		{
			const string binaryFileName = "random.Data";
			const string zipFileName = binaryFileName + ".zip";

			var gen = new RandomDataGenerator();
			gen.RandomDataGenerated += OnRandomDataGenerated;
			gen.RandomDataGenerationDone += OnRandomDataGenerationDone;

			var randomBytes = gen.GetRandomData(10, 1);

			
			File.WriteAllBytes(binaryFileName, randomBytes);

			if (File.Exists(zipFileName))
				File.Delete(zipFileName);

			using (var zip = ZipFile.Open(binaryFileName + ".zip", ZipArchiveMode.Create))
				zip.CreateEntryFromFile(binaryFileName, binaryFileName);
		}

		private static void OnRandomDataGenerated(object sender, RandomDataEventArgs e)
		{
			Console.WriteLine($"{e.BytesDone} from {e.TotalBytes}");
		}

		private static void OnRandomDataGenerationDone(object sender, RandomDataGenerationEventArgs e)
		{
			Console.WriteLine("Ready!");
			Console.WriteLine(Convert.ToBase64String(e.RandomDataArray));
		}
	}
}
