using System.Collections.Generic;
using lesson_22.CitiesDataStore.Core;

namespace lesson_22.CitiesDataStore.InMemory
{
	public class CitiesDataStore : ICitiesDataStore
	{
		public IDictionary<int, City> Cities { get; }

		public CitiesDataStore()
		{
			Cities = new Dictionary<int, City>();
		}
	}
}
