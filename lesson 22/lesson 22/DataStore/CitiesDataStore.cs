using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson_22.Models;

namespace lesson_22.DataStore
{
	public class CitiesDataStore
	{
		private static CitiesDataStore _citiesDataStore;

		public List<CityGetModel> Cities { get; }

		private CitiesDataStore()
		{
			Cities = new List<CityGetModel>
			{
				new CityGetModel
				{
					Id = 1,
					Name = "New-York",
					Description = "This is my favorite city",
					NumberOfPointsOfInterest = 100
				},
				new CityGetModel
				{
					Id = 2,
					Name = "Amsterdam",
					Description = "I ❤ Amster",
					NumberOfPointsOfInterest = 99
				}
			};
		}

		public static CitiesDataStore GetInstance()
		{
			if (_citiesDataStore == null)
				_citiesDataStore = new CitiesDataStore();

			return _citiesDataStore;
		}
	}
}
