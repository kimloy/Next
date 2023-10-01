using System.ComponentModel.DataAnnotations;

namespace next_api.Entities
{
    public class Week_Days
    {
        [Key]
        public required string Week_Day { get; set; }
    }
}
