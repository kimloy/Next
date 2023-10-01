using AutoMapper;
using next_api.Models;

namespace next_api.Profiles
{
    public class ParkProfile : Profile
    {
        public ParkProfile() 
        {
            CreateMap<PlaceDetailResult, Entities.Park>();
        }
    }
}
