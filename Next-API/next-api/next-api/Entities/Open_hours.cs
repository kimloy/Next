using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Open_hours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Week_Day { get; set; }

        [ForeignKey("Park_ID")]
        public Park? Park { get; set; }

        public string? Park_ID { get; set; }

        [Required]
        public required string Time { get; set; }
    }
}
