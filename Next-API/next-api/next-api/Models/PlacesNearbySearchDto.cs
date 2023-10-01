namespace next_api.Models
{
    public class PlacesNearbySearchDto
    {
            public List<object>? Html_attributions { get; set; }
            public List<PlaceDto>? Results { get; set; }
            public string? Status { get; set; }
    }
}
