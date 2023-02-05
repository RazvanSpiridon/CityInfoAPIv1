using CityInfoAPIv1.Context;
using CityInfoAPIv1.Entities;
using CityInfoAPIv1.Models;
using CityInfoAPIv1.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace CityInfoAPIv1.Services
{
    public class PointOfInterestService : IPointOfInterestService
    {
        private readonly CityInfoDbContext _dbContext;

        public PointOfInterestService(CityInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PointOfInterestDto> AddPointOfInterestAsync(PointOfInterestDto pointOfInterestDto)
        {
            var pointOfInterest = new PointOfInterest();
            pointOfInterest.PointOfInterestId = Guid.NewGuid();
            PointOfInterestDto.MapToEntity(pointOfInterest, pointOfInterestDto);

            await _dbContext.PointsOfInterest.AddAsync(pointOfInterest);
            await _dbContext.SaveChangesAsync();

            return PointOfInterestDto.MapToModel(pointOfInterest);
        }

        public async Task<PointOfInterestDto> DeletePointOfInterestAsync(Guid pointOfinterestId)
        {
            var pointOfInterest = await _dbContext.PointsOfInterest.Where(p => p.PointOfInterestId == pointOfinterestId).FirstOrDefaultAsync() ?? new PointOfInterest();
            _dbContext.PointsOfInterest.Remove(pointOfInterest);
            await _dbContext.SaveChangesAsync();

            return PointOfInterestDto.MapToModel(pointOfInterest);
        }

        public async Task<PointOfInterestDto> GetPointOfInterestAsync(Guid pointOfInterestId)
        {
            var pointOfInterest = await _dbContext.PointsOfInterest.Where(p => p.PointOfInterestId == pointOfInterestId).FirstOrDefaultAsync() ?? new PointOfInterest();

            return PointOfInterestDto.MapToModel(pointOfInterest);
        }

        public async Task<List<PointOfInterestDto>> GetPointsOfInterestAsync()
        {
            var pointsOfInterest = await _dbContext.PointsOfInterest.ToListAsync();

            var pointsOfInterestDto = new List<PointOfInterestDto>();
            foreach (var item in pointsOfInterest)
            {
                pointsOfInterestDto.Add(PointOfInterestDto.MapToModel(item));
            }

            return pointsOfInterestDto;
        }

        public async Task<PointOfInterestDto> UpdatePointOfInterestAsync(Guid pointOfInterestId, PointOfInterestDto pointOfInterestDto)
        {
            var pointOfInterest = await _dbContext.PointsOfInterest.Where(p => p.PointOfInterestId == pointOfInterestId).FirstOrDefaultAsync() ?? new PointOfInterest();

            PointOfInterestDto.MapToEntity(pointOfInterest, pointOfInterestDto);
            await _dbContext.SaveChangesAsync();
            return PointOfInterestDto.MapToModel(pointOfInterest);
        }
    }
}
