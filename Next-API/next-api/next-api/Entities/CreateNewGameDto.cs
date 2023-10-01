using next_api.Models;

namespace next_api.Entities
{
    public class CreateNewGameDto
    {
        public PlaceDetailDto? placeDetail { get; set; }
        public GameDto? Game { get; set; }

    }
}
