using lesson_22.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_22.Models
{
    public class CityCreateOrUpdateModel 
    {
		public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest { get; set; }

		public City ConvertToCity(int id)
		{
			return new City
			{
				Id = id,
				Name = Name,
				Description = Description,
				NumberOfPointsOfInterest = NumberOfPointsOfInterest
			};
		}
    }
}
