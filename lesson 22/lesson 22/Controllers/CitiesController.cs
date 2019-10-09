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
		public IActionResult AddCity([FromBody] City city)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			citiesDataStore.Cities.Add(city);

			return Created("/api/cities/" + city.Id, city);
		}
	}
}
