using CityInfoAPIv1.Models;

namespace CityInfoAPIv1.Services.IServices
{
    public interface IPointOfInterestService
    {
        Task<List<PointOfInterestDto>> GetPointsOfInterestAsync();
        Task<PointOfInterestDto> GetPointOfInterestAsync(Guid pointOfInterestId);
        Task<PointOfInterestDto> AddPointOfInterestAsync(PointOfInterestDto pointOfInterestDto);
        Task<PointOfInterestDto> UpdatePointOfInterestAsync(Guid pointOfInterestId, PointOfInterestDto pointOfInterestDto);
        Task<PointOfInterestDto> DeletePointOfInterestAsync(Guid pointOfinterestId);

    }
}
