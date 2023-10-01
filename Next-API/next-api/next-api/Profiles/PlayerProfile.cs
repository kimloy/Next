using AutoMapper;

namespace next_api.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile() 
        { 
            CreateMap<Entities.Player, Models.PlayerDto>();
            CreateMap<Models.PlayerDto, Entities.Player>();
        }
    }
}
