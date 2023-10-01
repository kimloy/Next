using System.ComponentModel.DataAnnotations;

namespace next_api.Models
{
    public class PhotoDto
    {
        public int Height { get; set; }
        public List<string>? Html_attributions { get; set; }
        public string? Photo_reference { get; set; }
        public int Width { get; set; }
    }
}
