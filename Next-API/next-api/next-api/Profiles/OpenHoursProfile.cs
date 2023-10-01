using AutoMapper;

namespace next_api.Profiles
{
    public class OpenHoursProfile : Profile
    {
        public OpenHoursProfile() 
        {
            CreateMap<Models.OpeningHoursDto, Entities.Open_hours>();
        }
    }
}
