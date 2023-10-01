using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Address_ID { get; set; }

        [ForeignKey("Park_ID")]
        public Park? Park { get; set; }

        public string? Park_ID { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string City { get; set; }

        [Required]
        public required string PostalCode { get; set; }

        [Required]
        public required string State { get; set; }

        [Required]
        public required string County { get; set; }

        [Required]
        public required string Country { get; set; }


    }
}
