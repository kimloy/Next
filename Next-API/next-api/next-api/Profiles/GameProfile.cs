using AutoMapper;

namespace next_api.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        { 
           CreateMap<Models.GameDto, Entities.Game>();
           CreateMap<Entities.Game, Models.GameDto>();
        }
    }
}
