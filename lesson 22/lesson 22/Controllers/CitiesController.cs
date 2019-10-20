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
            city cities = citiesDataStore.Cities;
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
        public IActionResult AddCity([FromBody] CityCreateOrUpdateModel city)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            int newCityId = citiesDataStore.Cities.Max(id => id.Id) + 1;

            var newCity = new City
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

            citiesDataStore.Cities.Remove(citiesDataStore
            .Cities
            .FirstOrDefault(c => c.Id == id));

            return NoContent();
        }

        [HttpPut("/api/cities/{id}")]
        public IActionResult ReplaceCity(int id, [FromBody] CityCreateOrUpdateModel cityModel)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();

            if (citiesDataStore.Cities[citiesDataStore.Cities.FindIndex(c => c.Id == id)] != null)
            {
                citiesDataStore.Cities[citiesDataStore.Cities.FindIndex(c => c.Id == id)] = new City
                {
                    Id = id,
                    Name = cityModel.Name,
                    Description = cityModel.Description,
                    NumberOfPointsOfInterest = cityModel.NumberOfPointsOfInterest
                };

                return Ok(GetCity(id));
            }
            else
                return NotFound();

        }
    }
}
