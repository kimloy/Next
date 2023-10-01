using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Sport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Sport_ID { get; set; }
    
        public GameDocInfo GameDocInfo { get; set; }

        [ForeignKey("GameDocInfo")]
        public int GameDocInfo_ID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int Max_Num_Players { get; set; }
        
    }
}
