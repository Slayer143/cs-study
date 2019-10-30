using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using lesson_22.DataStore;
using lesson_22.DataValidation;

namespace lesson_22.Models
{
    public class CityCreateOrUpdateModel 
    {
		[Required(ErrorMessage = "Field 'Name' is required field"), 
		MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255),
		OtherAttribute("Name")]
        public string Description { get; set; }
		
		[Range(0, 100)]
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
