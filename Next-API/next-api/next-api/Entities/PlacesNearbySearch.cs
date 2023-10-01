using System.ComponentModel.DataAnnotations;

namespace next_api.Entities
{
    public class PlacesNearbySearch
    {
        [Key]
        public string place_id { get; set; } = string.Empty;


        public string business_status { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        [Required]
        public double longitude { get; set; }

        [Required]
        public double latitude { get; set; }
    }
}
