using AutoMapper;

namespace next_api.Profiles
{
    public class GameDocInfoProfile : Profile
    {
        public GameDocInfoProfile() 
        { 
            CreateMap<Entities.GameDocInfo, Models.GameDocInfoDto>();
        }
    }
}
