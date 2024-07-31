using AutoMapper;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Order;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Mappers.AutoMapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>()
               
                .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ProductName == null
                                         ? ""
                                         : src.ProductName.ToUpper()))
                .ForMember(
                dest => dest.UnitPrice,
                opt => opt.MapFrom(src => src.UnitPrice == null
                                         ? 0
                                         : src.UnitPrice.Value * 1.2m));
            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();


           

          
            
        }
    }
}
