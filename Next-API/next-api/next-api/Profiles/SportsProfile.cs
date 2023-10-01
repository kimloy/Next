using AutoMapper;

namespace next_api.Profiles
{
    public class SportsProfile : Profile
    {
        public SportsProfile() 
        { 
            CreateMap<Entities.Sport, Models.SportDto>();
        
        }
    }
}
