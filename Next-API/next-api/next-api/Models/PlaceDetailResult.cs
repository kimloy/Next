namespace next_api.Models
{
    public class PlaceDetailResult
    {
        public List<AddressComponentDto>? Address_Components { get; set; }
        public string Adr_Address { get; set; } = String.Empty;
        public string Business_Status { get; set; } = String.Empty;
        public string Formatted_Address { get; set; } = String.Empty;
        public string Formatted_Phone_Number { get; set; } = String.Empty;
        public GeometryDto? Geometry { get; set; }
        public string Icon { get; set; } = String.Empty;
        public string Icon_Background_Color { get; set; } = String.Empty;
        public string Icon_Mask_Base_Uri { get; set; } = String.Empty;
        public string International_Phone_Number { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public OpeningHoursDto? Opening_Hours { get; set; }
       
        public ClosingHoursDto? Closing_Hours { get; set; } 

        public List<PhotoDto>? Photos { get; set; }
        public string Place_Id { get; set; } = String.Empty;
        public PlusCodeDto? Plus_Code { get; set; }
        public double Rating { get; set; }
        public string Reference { get; set; } = String.Empty;
        public List<ReviewDto>? Reviews { get; set; }
        public List<string>? Types { get; set; }
        public string Url { get; set; } = String.Empty;
        public int User_Ratings_Total { get; set; }
        public int Utc_Offset { get; set; }
        public string Vicinity { get; set; } = String.Empty;
        public string Website { get; set; } = String.Empty;
    }
}
