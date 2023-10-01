using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace next_api.Entities
{
    public class Geometry
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Geometry_ID { get; set; }

        [ForeignKey("Park_ID")]
        public Park? Park { get; set; }

        public string? Park_ID { get; set; }

        public Location? Location { get; set; }

    }
}
