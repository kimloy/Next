namespace next_api.Models
{
    public class ClosingHoursDto
    {
        public bool Open_Now { get; set; }
        public List<PeriodDto>? Periods { get; set; }
        public List<string>? Weekday_Text { get; set; }
    }
}
