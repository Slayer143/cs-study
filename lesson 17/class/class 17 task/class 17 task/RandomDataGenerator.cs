using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace class_17_task
{
	class RandomDataGenerator
	{
		public EventHandler<RandomDataEventArgs> RandomDataGenerated;

		public EventHandler<RandomDataGenerationEventArgs> RandomDataGenerationDone;

		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{

			var randomDataArray = new byte[dataSize];
			var rand = new Random();

			for (int i = 0; i < dataSize; i++)
			{
				randomDataArray[i] = (byte)rand.Next(256);

				if ((i + 1) % bytesDoneToRaiseEvent == 0)
				{
					Thread.Sleep(200);

					var e = new RandomDataEventArgs
					{
						BytesDone = i + 1,
						TotalBytes = dataSize
					};

					OnRandomDataGenerated(
						i + 1,
						e);
				}
			}

			RandomDataGenerationDone(
				this,
				new RandomDataGenerationEventArgs
				{
					RandomDataArray = randomDataArray
				});
			return randomDataArray;
		}

		protected virtual void OnRandomDataGenerated(object sender, RandomDataEventArgs e)
		{
			RandomDataGenerated?.Invoke(this, e);
		}
	}
}
