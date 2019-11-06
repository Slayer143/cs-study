using lesson_22.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_22.CitiesDataStore.Core
{
    interface ICitiesDataStore 
    {
        Dictionary<int, City> Cities { get; }
    }
}
