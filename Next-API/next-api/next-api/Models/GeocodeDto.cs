namespace next_api.Models
{
    public class GeocodeDto
    {
        public List<AddressComponentDto>? address_components { get; set; }
        public string formatted_address { get; set; } = string.Empty;
        public GeolocationGeometryDto? geometry { get; set; }
        public string place_id { get; set; } = string.Empty;
        public PlusCodeDto? plus_code { get; set; }
        public List<string>? types { get; set; }
    }
}
