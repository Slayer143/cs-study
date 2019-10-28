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

			var citiesGetModelList = citiesDataStore
				.Cities
				.Values
				.Select(c => new CityGetModel(c))
				.ToList();

			return Ok(citiesGetModelList);
		}

		[HttpGet("/api/cities/{id}")]
		public IActionResult GetCityModel(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				var city = citiesDataStore.Cities[id];

				if (city == null)
					return NotFound();

				return Ok(city);
			}
			return NotFound();
		}

		[HttpPost("/api/cities/")]
		public IActionResult AddCity([FromBody] CityCreateOrUpdateModel cityCreate)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			City newCity = cityCreate.ConvertToCity(citiesDataStore.Cities.Max(c => c.Key) + 1);
			citiesDataStore.Cities.Add(newCity.Id, newCity);

			return CreatedAtRoute("/api/cities/", new { id = newCity.Id }, new CityGetModel(newCity));
		}

		[HttpDelete("/api/cities/{id}")]
		public IActionResult DeleteCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				citiesDataStore.Cities.Remove(id);
				return NoContent();
			}
			return NotFound();
		}

		[HttpPut("/api/cities/{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityCreateOrUpdateModel cityUpdate)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();

			if (citiesDataStore.Cities.ContainsKey(id))
			{
				citiesDataStore.Cities[id].Name = cityUpdate.Name;
				citiesDataStore.Cities[id].Description = cityUpdate.Description;
				citiesDataStore.Cities[id].NumberOfPointsOfInterest = cityUpdate.NumberOfPointsOfInterest;

				return Ok(new CityGetModel(citiesDataStore.Cities[id]));
			}
				return NotFound();
		}
	}
}
