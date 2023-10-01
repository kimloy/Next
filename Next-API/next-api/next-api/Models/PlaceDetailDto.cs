namespace next_api.Models
{
    public class PlaceDetailDto
    {
        public List<object>? Html_Attributions { get; set; }
        public PlaceDetailResult? Result { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
