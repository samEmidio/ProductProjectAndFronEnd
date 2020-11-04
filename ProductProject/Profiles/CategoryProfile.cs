using AutoMapper;
using ProductProject.Dto.Category;
using ProductProject.Model;

namespace ProductProject.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryReadDto>();
            CreateMap<CategoryCreateDto,Category>();
            CreateMap<CategoryUpdateDto,Category>();
            CreateMap<Category,CategoryUpdateDto>();
        }
    }
}