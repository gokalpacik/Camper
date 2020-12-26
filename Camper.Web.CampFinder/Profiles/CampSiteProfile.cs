using AutoMapper;

namespace Camper.Services.CampFinder.Profiles
{
    public class CampSiteProfile : Profile
    {
        public CampSiteProfile()
        {
            CreateMap<Entities.CampSite, Models.CampSiteDto>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.Name));
        }
    }
}
