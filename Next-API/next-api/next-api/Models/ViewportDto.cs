using static next_api.Models.PlacesNearbySearchDto;

namespace next_api.Models
{
    public class ViewportDto
    {
        public NortheastDto? Northeast { get; set; }
        public SouthwestDto? Southwest { get; set; }
    }
}
