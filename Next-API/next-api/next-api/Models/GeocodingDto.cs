namespace next_api.Models
{
    public class GeocodingDto
    {
        public List<GeocodeDto>? Results { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
