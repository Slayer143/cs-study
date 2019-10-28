using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson_22.DataStore;

namespace lesson_22.Models
{
	public class CityGetModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int NumberOfPointsOfInterest { get; set; }

		public CityGetModel(City city)
		{
			Id = city.Id;
			Name = city.Name;
			Description = city.Description;
			NumberOfPointsOfInterest = city.NumberOfPointsOfInterest;
		}
	}
}
