using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Player_ID { get; set; }

        [ForeignKey("Park_ID")]
        public virtual Park? Park { get; set; }

        public string? Park_ID { get; set; }

        public virtual Game? Game { get; set; } 

        public string? Game_ID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Date_Of_Birth { get; set; }

        public int? Age { get; set; }
    }
}
