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
            if (!await _cityService.CityExistsAsync(cityId))
                return NotFound("City do not exist!");

            return Ok(await _cityService.GetCityAsync(cityId));
        }
        [HttpGet]
        [Route("GetCitiesWithPointsOfInterest/{cityId}")]
        public async Task<ActionResult<List<CityWithPointsDto>>> GetCitiyWithPointsOfInterest(Guid cityId)
        {
            if (!await _cityService.CityExistsAsync(cityId))
                return NotFound("City do not exist!");

            return Ok(await _cityService.GetCityWithPointsOfInterestAsync(cityId));
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
            if (!await _cityService.CityExistsAsync(cityId))
                return NotFound("City do not exist!");

            return Ok(await _cityService.UpdateCityAsync(cityId, cityDto));
        }

        [HttpDelete]
        [Route("{cityId}")]
        public async Task<ActionResult<CityDto>> DeleteCity([FromRoute] Guid cityId)
        {
            if (!await _cityService.CityExistsAsync(cityId))
                return NotFound("City do not exist!");
            return Ok(await _cityService.DeleteCityAsync(cityId));
        }
    }
}
