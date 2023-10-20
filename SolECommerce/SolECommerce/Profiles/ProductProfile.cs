using AutoMapper;
using SolECommerce.DataAccess.DBEntities;
using SolECommerce.Models;

namespace SolECommerce.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductCatalogModel>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        }
    }
}
