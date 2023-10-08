using next_api.Entities;

namespace next_api.Models
{
    public class GameDto
    {
        public string? Game_ID { get; set; }

        public  string? Place_id { get; set; }

        public  string? Player_ID { get; set; }

        public ICollection<PlayerDto>? Players { get; set; } = new List<PlayerDto>();

        public  string? Sport_Name { get; set; }

        public  string? Name { get; set; }

        public int Number_Of_Players { get; set; }

        public  string? DateTime { get; set; }

        public bool? Active { get; set; }

        public string? Game_Master { get; set; }


    }
}
