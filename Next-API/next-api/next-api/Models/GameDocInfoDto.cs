namespace next_api.Models
{
    public class GameDocInfoDto
    {
        public int Id { get; set; }

        public ICollection<SportDto> Sports_List { get; set; }  = new List<SportDto>();
    } 
}
