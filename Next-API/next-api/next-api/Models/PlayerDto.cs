using next_api.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Models
{
    public class PlayerDto
    {
        public required string Player_ID { get; set; }

        public required string Name { get; set; }

        public required string Date_Of_Birth { get; set; }

        public string? Park_ID { get; set; }

        public int? Age { get; set; }

    }
}
