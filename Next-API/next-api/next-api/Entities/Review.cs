using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; } 

        [ForeignKey("Park_ID")]
        public Park? Park { get; set; }

        public string? Park_ID { get; set; }

        public string Author_Name { get; set; } = string.Empty;

        public string Author_Url { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string Profile_Photo_Url { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string Relative_Time_Description { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public int Time { get; set; }
    }
}
