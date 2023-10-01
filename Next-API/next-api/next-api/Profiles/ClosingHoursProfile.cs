using AutoMapper;
using next_api.Entities;
using next_api.Models;

namespace next_api.Profiles
{
    public class ClosingHoursProfile : Profile
    {
        public ClosingHoursProfile() 
        {
            CreateMap<ClosingHoursDto, Closing_Hours>();
        }
    }
}
