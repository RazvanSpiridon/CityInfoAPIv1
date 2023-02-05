using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfoAPIv1.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public Guid CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string CityDescription { get; set; } = null!;

        public List<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();
        public City()
        {

        }

        public City(Guid cityId, string cityName, string cityDescription)
        {
            CityId = cityId;
            CityName = cityName;
            CityDescription = cityDescription;
        }
    }
}
