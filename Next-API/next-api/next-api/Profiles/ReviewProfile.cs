using AutoMapper;

namespace next_api.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Models.ReviewDto, Entities.Review>();

        }
    }
}
