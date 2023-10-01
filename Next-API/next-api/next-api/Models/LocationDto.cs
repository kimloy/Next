using System.ComponentModel.DataAnnotations;

namespace next_api.Models
{
    public class LocationDto
    {
        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }
    }
}
