using CityInfoAPIv1.Models;

namespace CityInfoAPIv1.Services.IServices
{
    public interface ICityService
    {
        Task<bool> CityExistsAsync(Guid cityId);
        Task<List<CityDto>> GetCitiesAsync();
        Task<CityDto> GetCityAsync(Guid cityId);
        Task<CityDto> AddCityAsync(CityDto cityDto);
        Task<CityDto> UpdateCityAsync(Guid cityId, CityDto cityDto);
        Task<int> DeleteCityAsync(Guid cityId);
        Task<List<CityWithPointsDto>> GetCitiesWithPointsOfInterestAsync();
        Task<CityWithPointsDto> GetCityWithPointsOfInterestAsync(Guid cityId);

    }
}
