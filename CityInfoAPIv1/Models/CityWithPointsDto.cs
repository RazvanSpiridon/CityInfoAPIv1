using CityInfoAPIv1.Entities;

namespace CityInfoAPIv1.Models
{
    public class CityWithPointsDto
    {
        public string CityName { get; set; } = null!;
        public string CityDescription { get; set; } = null!;

        public List<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();

        public CityWithPointsDto()
        {

        }

        public CityWithPointsDto(string cityName, string cityDescription, List<PointOfInterest> pointsOfInterest)
        {
            CityName= cityName;
            CityDescription= cityDescription;
            PointsOfInterest= pointsOfInterest;
        }
    }
}
