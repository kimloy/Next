using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Day
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Day_ID { get; set; }

        [ForeignKey("Park_ID")]
        public required string Park_ID { get; set; }

        [ForeignKey("Week_Day")]
        public required string Week_Day { get; set; }

        [ForeignKey("Game_ID")]
        public string? Game_ID { get; set; }

        [Required]
        public required string Time { get; set; }
    }
}
