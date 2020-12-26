using AutoMapper;

namespace Camper.Services.CampFinder.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryDto>().ReverseMap();
        }
    }
}
