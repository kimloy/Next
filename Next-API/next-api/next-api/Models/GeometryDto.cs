using System.ComponentModel.DataAnnotations;

namespace next_api.Models
{
    public class GeometryDto
    {
        
        public LocationDto? Location { get; set; }

       
        public ViewportDto? Viewport { get; set; }
    }
}
