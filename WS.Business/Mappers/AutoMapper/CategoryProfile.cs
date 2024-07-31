using AutoMapper;
using WS.Model.Dtos.Category;
using WS.Model.Entities;

namespace WS.Business.Mappers.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();


            CreateMap<CategoryPostDto, Category>()
                            .ForMember(dest => dest.Picture,
                                 opt =>
                                 opt.MapFrom(src => Convert.FromBase64String(src.Base64Picture))
             );

            CreateMap<CategoryPutDto, Category>();


        }
    }
}
