using CityInfoAPIv1.Models;
using CityInfoAPIv1.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPIv1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestService _pointOfInterestService;
        private readonly ICityService _cityService;

        public PointOfInterestController(IPointOfInterestService pointOfInterestService, ICityService cityService)
        {
            _pointOfInterestService = pointOfInterestService;
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PointOfInterestDto>>> GetPointsOfInterest()
        {
            return Ok(await _pointOfInterestService.GetPointsOfInterestAsync());
        }


        [HttpGet]
        [Route("{pointOfInterestId}")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(Guid pointOfInterestId)
        {
            return Ok(await _pointOfInterestService.GetPointOfInterestAsync(pointOfInterestId));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> AddPointOfInterest(PointOfInterestDto pointOfInterestDto)
        {
            if (!await _cityService.CityExistsAsync(pointOfInterestDto.CityId))
                return BadRequest("City was not found!");
            
            return Ok(await _pointOfInterestService.AddPointOfInterestAsync(pointOfInterestDto));
        }

        [HttpPut]
        [Route("{pointOfInterestId}")]
        public async Task<ActionResult<PointOfInterestDto>> UpdatePointOfInterest(Guid pointOfInterestId, PointOfInterestDto pointOfInterestDto)
        {
            if (!await _cityService.CityExistsAsync(pointOfInterestDto.CityId))
                return BadRequest("City was not found!");

            return Ok(await _pointOfInterestService.UpdatePointOfInterestAsync(pointOfInterestId, pointOfInterestDto));
        }

        [HttpDelete]
        [Route("{pointOfInterestId}")]
        public async Task<ActionResult<PointOfInterestDto>> DeletePointOfInterest(Guid pointOfInterestId)
        {
            return Ok(await _pointOfInterestService.DeletePointOfInterestAsync(pointOfInterestId));
        }
    }
}
