using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class AddressComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string AddressComponent_ID { get; set; }

        [ForeignKey("Park_ID")]
        public Park? Park { get; set; }

        public string? Park_ID { get; set; }

        public string Long_name { get; set; } = string.Empty;

        public string Short_name { get; set; } = string.Empty;

    }
}
