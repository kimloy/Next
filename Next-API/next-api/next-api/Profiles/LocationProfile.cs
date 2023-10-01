using AutoMapper;

namespace next_api.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile() 
        {
            CreateMap<Models.LocationDto, Entities.Location>();
        }
    }
}
