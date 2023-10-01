using AutoMapper;

namespace next_api.Profiles
{
    public class GeometryProfile : Profile
    {
        public GeometryProfile() 
        {
            CreateMap<Models.GeometryDto, Entities.Geometry>();
        }
    }
}
