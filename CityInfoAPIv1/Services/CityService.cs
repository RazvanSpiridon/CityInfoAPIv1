using CityInfoAPIv1.Context;
using CityInfoAPIv1.Entities;
using CityInfoAPIv1.Models;
using CityInfoAPIv1.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPIv1.Services
{
    public class CityService : ICityService
    {
        private readonly CityInfoDbContext _dbContext;

        public CityService(CityInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<CityDto> AddCityAsync(CityDto cityDto)
        {
            var city = new City
            {
                
                CityId = new Guid(),
                CityName = cityDto.CityName,
                CityDescription= cityDto.CityDescription,
            };

            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

            return new CityDto(city.CityId, city.CityName, city.CityDescription);
        }

        public async Task<bool> CityExistsAsync(Guid cityId)
        {
            return await _dbContext.Cities.AnyAsync(c =>c.CityId == cityId);
        }

        public async Task<int> DeleteCityAsync(Guid cityId)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(c => c.CityId == cityId) ?? new City();
            if (city.CityId != Guid.Empty )
            {
                _dbContext.Cities.Remove(city);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return -1;
        }

        public async Task<List<CityDto>> GetCitiesAsync()
        {
            var cities = await _dbContext.Cities.ToListAsync();

            return cities.Select(c => new CityDto(
                c.CityId,
                c.CityName,
                c.CityDescription
                )).ToList();
        }

        public async Task<List<CityWithPointsDto>> GetCitiesWithPointsOfInterestAsync()
        {
            var cities = await _dbContext.Cities.Include(p => p.PointsOfInterest).ToListAsync();

            return cities.Select(c => new CityWithPointsDto(
                c.CityName,
                c.CityDescription,
                c.PointsOfInterest
                )).ToList();
        }

        public async Task<CityDto> GetCityAsync(Guid cityId)
        {
            var city = await _dbContext.Cities.Where(c => c.CityId == cityId).FirstOrDefaultAsync() ?? new City();
            
            return new CityDto(city.CityId, city.CityName, city.CityDescription);
        }

        public async Task<CityWithPointsDto> GetCityWithPointsOfInterestAsync(Guid cityId)
        {
            var city = await _dbContext.Cities.Where(c => c.CityId == cityId).Include(p => p.PointsOfInterest).FirstOrDefaultAsync() ?? new City();

            return new CityWithPointsDto(city.CityName, city.CityDescription, city.PointsOfInterest);
        }

        public async Task<CityDto> UpdateCityAsync(Guid cityId, CityDto cityDto)
        {
            var city = await _dbContext.Cities.Where(c => c.CityId == cityId).FirstOrDefaultAsync() ?? new City();
            city.CityName = cityDto.CityName;
            city.CityDescription = cityDto.CityDescription;

            await _dbContext.SaveChangesAsync();

            return new CityDto(city.CityId, city.CityName, city.CityDescription);
        }
    }
}
