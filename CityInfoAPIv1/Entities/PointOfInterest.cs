using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CityInfoAPIv1.Entities
{
    [Table("PointOfInterest")]
    public class PointOfInterest
    {
        [Key]
        public Guid PointOfInterestId { get; set; }
        public string PointOfInterestName { get; set; } = null!;
        public string PointOfInterestDescription { get; set; } = null!;

        [ForeignKey("CityId")]
        public Guid CityId { get; set; }
        [JsonIgnore]
        public City? City { get; set; } 

        public PointOfInterest()
        {

        }

    }
}
