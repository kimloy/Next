using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Game_ID { get; set; }

        public virtual Park? Park { get; set; }

        public string? Park_ID { get; set; }

        public string? Place_id { get; set; }

        public ICollection<Player>? Players { get; set; } = new List<Player>();

        [Required]
        public required string Name { get; set; }

        [Required] 
        public string? Sport_Name { get; set; }

        [Required]
        public required int Number_Of_Players { get; set; }

        [Required]
        public required string DateTIme { get; set; }

        public bool Active { get; set; }


    }
}
