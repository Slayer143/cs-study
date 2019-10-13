using lesson_22.DataStore;
using lesson_22.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lesson_22.Controllers
{
	public class CitiesController : Controller
	{
		[HttpGet("/api/cities")]
		public IActionResult GetCities()
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var cities = citiesDataStore.Cities;
			return Ok(cities);
		}

		[HttpGet("/api/cities/{id}")]
		public IActionResult GetCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			var city = citiesDataStore
				.Cities
				.FirstOrDefault(c => c.Id == id);

			if (city == null)
				return NotFound();

			return Ok(city);
		}

        [HttpPost("/api/cities/")]
        public IActionResult AddCity([FromBody] CityCreateModel city)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            int newCityId = citiesDataStore.Cities.Count() + 1;

            var newCity = new CityGetModel
            {
                Id = newCityId,
                Name = city.Name,
                Description = city.Description,
                NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
            };
            citiesDataStore.Cities.Add(newCity);

			return CreatedAtRoute("/api/cities/", new { id = newCityId }, newCity);
		}

        [HttpDelete("/api/cities/{id}")]
        public IActionResult DeleteCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();

            foreach (var cities in citiesDataStore.Cities)
            {
                if (cities.Id > id)
                    cities.Id--;
            }

            citiesDataStore.Cities.Remove(citiesDataStore
            .Cities
            .FirstOrDefault(c => c.Id == id));

            return Ok(citiesDataStore.Cities);
        }

        [HttpPut("/api/cities/{id}")]
        public IActionResult ReplaceCity(int id, [FromBody] CityCreateModel cityModel)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();

            citiesDataStore.Cities[citiesDataStore.Cities.FindIndex(c => c.Id == id)] = new CityGetModel
            {
                Id = id,
                Name = cityModel.Name,
                Description = cityModel.Description,
                NumberOfPointsOfInterest = cityModel.NumberOfPointsOfInterest
            };

            return Ok(citiesDataStore.Cities);
        }
    }
}
