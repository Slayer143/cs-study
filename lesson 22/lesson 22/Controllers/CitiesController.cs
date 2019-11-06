using System.Linq;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using lesson_22.CitiesDataStore.Core;
using lesson_22.Models;

namespace lesson_22.Controllers
{
	[Route("/api/cities/")]
	public class CitiesController : Controller
	{
		private ICitiesDataStore _citiesDataStore;
		private ILogger<CitiesController> _logger;

		public CitiesController(
			ICitiesDataStore citiesDataStore,
			ILogger<CitiesController> logger)
		{
			_citiesDataStore = citiesDataStore;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetCities()
		{
			_logger.LogInformation("Method GetCities() called");

			try
			{
				var citiesGetModelList = _citiesDataStore
					.Cities
					.Values
					.Select(c => new CityGetModel(c))
					.ToList();

				return Ok(citiesGetModelList);
			}
			catch(Exception e)
			{
				_logger.LogError(
					e,
					"Error in GetCities() method");

				throw;
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetCityModel(int id)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				var city = _citiesDataStore.Cities[id];

				if (city == null)
					return NotFound();

				return Ok(city);
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult AddCity([FromBody] CityCreateOrUpdateModel cityCreate)
		{
			//ModelState.AddModelError("Custom", "Something goes wrong");

			if (cityCreate == null)
				return BadRequest();

			//if (cityCreate.Description == cityCreate.Name)
			//	ModelState.AddModelError("Description", "Do not write same things in fields 'Name' and 'Description'");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			int id = _citiesDataStore.Cities.Keys.Count == 0
				? 1
				: _citiesDataStore.Cities.Keys.Max() + 1;

			City newCity = cityCreate.ConvertToCity(id);
			_citiesDataStore.Cities.Add(newCity.Id, newCity);

			return CreatedAtRoute("/api/cities/", new { id = newCity.Id }, new CityGetModel(newCity));
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCity(int id)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				_citiesDataStore.Cities.Remove(id);
				return NoContent();
			}
			return NotFound();
		}

		[HttpPut("{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityCreateOrUpdateModel cityUpdate)
		{
			if (id <= 0)
				ModelState.AddModelError("id", "ID should be an integer value greater than 0");

			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			if (_citiesDataStore.Cities.ContainsKey(id))
			{
				_citiesDataStore.Cities[id].Name = cityUpdate.Name;
				_citiesDataStore.Cities[id].Description = cityUpdate.Description;
				_citiesDataStore.Cities[id].NumberOfPointsOfInterest = cityUpdate.NumberOfPointsOfInterest;

				return Ok(new CityGetModel(_citiesDataStore.Cities[id]));
			}
			return NotFound();
		}
	}
}
