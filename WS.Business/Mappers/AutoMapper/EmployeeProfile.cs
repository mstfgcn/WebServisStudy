using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Mappers.AutoMapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                .ForMember(dest=>dest.BirthDate,
                    opt=>opt.MapFrom(src=>src.BirthDate))
                .ForMember(dest=>dest.Country,
                    opt=>opt.MapFrom(src=>src.Country))
                .ForMember(dest=>dest.City,
                    opt=>opt.MapFrom(src=>src.City))
                .ForMember(
                    dest => dest.Orders,
                    opt => opt.MapFrom(src => src.Orders == null
                        ? ""
                        : src.Orders[0].ShipName));
            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployePutDto,Employee>();
        }
    }
}

