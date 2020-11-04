using AutoMapper;
using ProductProject.Dto.Product;
using ProductProject.Model;

namespace ProductProject.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductReadDto>();
            CreateMap<ProductCreateDto,Product>();
            CreateMap<ProductUpdateDto,Product>();
            CreateMap<Product,ProductUpdateDto>();
        }
    }
}