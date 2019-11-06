using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_22.CitiesDataStore.Core
{
    interface ICitiesModels
    {
        string Name { get; set; }

        string Description { get; set; }

        int NumberOfPointsOfInterest { get; set; }
    }
}
