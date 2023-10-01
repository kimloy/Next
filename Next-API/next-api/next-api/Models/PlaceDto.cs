using static next_api.Models.PlacesNearbySearchDto;

namespace next_api.Models
{
    public class PlaceDto
    {
        public string? Business_status { get; set; }
        public GeometryDto? Geometry { get; set; }
        public string? Icon { get; set; }
        public string? Icon_background_color { get; set; }
        public string? Icon_mask_base_uri { get; set; }
        public string? Name { get; set; }
        public OpeningHoursDto? Opening_hours { get; set; }
        public List<PhotoDto>? Photos { get; set; }
        public string? Place_id { get; set; }
        public PlusCodeDto? Plus_code { get; set; }
        public int Price_level { get; set; }
        public double Rating { get; set; }
        public string? Reference { get; set; }
        public string? Scope { get; set; }
        public List<string>? Types { get; set; }
        public int User_ratings_total { get; set; }
        public string? Vicinity { get; set; }
    }
}
