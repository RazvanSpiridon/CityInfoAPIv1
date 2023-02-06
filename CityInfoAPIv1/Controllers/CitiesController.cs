using CityInfoAPIv1.Models;
using CityInfoAPIv1.Services;
using CityInfoAPIv1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<CityDto>> GetCities()
        {
            return Ok(await _cityService.GetCitiesAsync());
        }

        [HttpGet]
        [Route("GetCitiesWithPointsOfInterest")]
        public async Task<ActionResult<List<CityWithPointsDto>>> GetCitiesWithPointsOfInterest()
        {
            return Ok(await _cityService.GetCitiesWithPointsOfInterestAsync());
        }

        [HttpGet]
        [Route("{cityId}")]
        public async Task<ActionResult<CityDto>> GetCity([FromRoute] Guid cityId)
        {
            var city = await _cityService.GetCityAsync(cityId);
            
            if (city.CityId == Guid.Empty)
                return NotFound();

            return Ok(city);

        }
        [HttpGet]
        [Route("GetCitiesWithPointsOfInterest/{cityId}")]
        public async Task<ActionResult<List<CityWithPointsDto>>> GetCitiyWithPointsOfInterest(Guid cityId)
        {
            var city = await _cityService.GetCityWithPointsOfInterestAsync(cityId);

            if (city.CityName == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> AddCity(CityDto cityDto)
        {
            return Ok(await _cityService.AddCityAsync(cityDto));
        }

        [HttpPut]
        [Route("{cityId}")]
        public async Task<ActionResult<CityDto>> UpdateCity([FromRoute] Guid cityId, CityDto cityDto)
        {
            var city = await _cityService.UpdateCityAsync(cityId, cityDto);

            if (city.CityId == Guid.Empty)
                return NotFound();

            return Ok(city);
        }

        [HttpDelete]
        [Route("{cityId}")]
        public async Task<ActionResult> DeleteCity([FromRoute] Guid cityId)
        {
            var city = await _cityService.DeleteCityAsync(cityId);
            if (city == -1)
                return NotFound();

            return Ok($"The city with id {cityId} was deleted");

        }
    }
}
