using System.Collections.Generic;

namespace lesson_22.CitiesDataStore.Core
{
	public interface ICitiesDataStore 
    {
        IDictionary<int, City> Cities { get; }
    }
}
