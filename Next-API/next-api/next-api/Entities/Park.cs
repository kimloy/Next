using next_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace next_api.Entities
{
    public class Park
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string Id { get; set; }

        public List<AddressComponent>? AddressComponents { get; set; }

        [Required]
        public Geometry? Geometry { get; set; }

        public Open_hours? OpenHours { get; set; }

        public Closing_Hours? CloseHours { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Game>? Games { get; set; } = new List<Game>();

        public virtual ICollection<Player>? Players { get; set; } = new List<Player>();


        public string? Icon { get; set; }

        public string? Icon_Background_Color { get; set; }

        public string? Icon_Mask_Base_Uri { get; set; } 

        public string? International_Phone_Number { get; set; }

        public string? Name { get; set; } 

        public string? Place_Id { get; set; } 

        public double Rating { get; set; }

        public string? Reference { get; set; }

        public string? Url { get; set; } 

        public int User_Ratings_Total { get; set; }

        public int Utc_Offset { get; set; }

        public string? Vicinity { get; set; } 

        public string? Website { get; set; }

    }
}
