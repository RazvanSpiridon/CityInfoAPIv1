using CityInfoAPIv1.Entities;

namespace CityInfoAPIv1.Models
{
    public class PointOfInterestDto
    {
        public Guid PointOfInterestId { get; set; }
        public string PointOfInterestName { get; set; } = null!;
        public string PointOfInterestDescription { get; set; } = null!;
        public Guid CityId { get; set; }

        public static PointOfInterestDto MapToModel(PointOfInterest pointOfInterest)
        {
            return new PointOfInterestDto
            {
                PointOfInterestId = pointOfInterest.PointOfInterestId,
                PointOfInterestName = pointOfInterest.PointOfInterestName,
                PointOfInterestDescription = pointOfInterest.PointOfInterestDescription,
                CityId = pointOfInterest.CityId
            };
        }

        public static void MapToEntity(PointOfInterest pointOfInterest, PointOfInterestDto pointOfInterestDto)
        {
            pointOfInterest.PointOfInterestName = pointOfInterestDto.PointOfInterestName;
            pointOfInterest.PointOfInterestDescription = pointOfInterestDto.PointOfInterestDescription;
            pointOfInterest.CityId = pointOfInterestDto.CityId;
        }
    }
}
