namespace CityInfoAPIv1.Models
{
    public class CityDto
    {
        public Guid CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string CityDescription { get; set; } = null!;

        public CityDto(Guid cityId, string cityName, string cityDescription)
        {
            CityId = cityId;
            CityName = cityName;
            CityDescription = cityDescription;
        }
    }
}
