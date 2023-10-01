using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class GameDocInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [InverseProperty("GameDocInfo")]
        public ICollection<Sport> Sports_List { get; set; } = new List<Sport>();
    }
}
