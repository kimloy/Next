namespace next_api.Models
{
    public class ReviewDto
    {
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
