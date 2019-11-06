using System.ComponentModel.DataAnnotations;
using lesson_22.DataValidation;
using lesson_22.CitiesDataStore.Core;

namespace lesson_22.Models
{
	public class CityCreateOrUpdateModel : ICitiesModels
    {
		[Required(ErrorMessage = "Field 'Name' is required field"), 
		MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255),
		OtherAttribute("Name")]
        public string Description { get; set; }
		
		[Range(0, 100),
        IntegerValue("NumberOfPointsOfInterest")]
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
