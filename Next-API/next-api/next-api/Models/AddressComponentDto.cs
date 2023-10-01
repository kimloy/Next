namespace next_api.Models
{
    public class AddressComponentDto
    {
        public string long_name { get; set; } = string.Empty;
        public string short_name { get; set; } = string.Empty;
        public List<string>? types { get; set; }
    }
}
