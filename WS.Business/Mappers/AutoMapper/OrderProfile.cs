using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.Order;
using WS.Model.Dtos.Product;
using WS.Model.Entities;

namespace WS.Business.Mappers.AutoMapper
{
    public class OrderProfile:Profile
    {
        public OrderProfile() {
            //CreateMap<Order, OrderGetDto>()
            //    .ForMember(dest => dest.OrderId,opt => opt.MapFrom(src => src.OrderId))
            //    .ForMember(dest => dest.EmployeeName== null, opt => opt.MapFrom(src => src.Employee==null 
            //                                                                          ? ""
            //                                                                          :src.Employee.FirstName+src.Employee.LastName))
            //    //.ForMember(dest => dest.CustomerName==null, opt => opt.MapFrom(src => src.CustomerId ==null
            //    //                                                                      ?""
            //    //                                                                      :src.CustomerId.CustomerName))
            //    .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            //    .ForMember(dest => dest.RequiredDate, opt => opt.MapFrom(src => src.RequiredDate))
            //    .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.ShippedDate))
            //    .ForMember(dest => dest.Freight, opt => opt.MapFrom(src => src.Freight))
            //    //.ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.Shippers ==null
            //    //                                                                ?""
            //    //                                                                :src=>src.Shippers.CompanyName))
            //    .ForMember(dest => dest.ShipName, opt => opt.MapFrom(src => src.ShipName))
            //    .ForMember(dest => dest.ShipCity, opt => opt.MapFrom(src => src.ShipCity))
            //    .ForMember(dest => dest.ShipCity, opt => opt.MapFrom(src => src.ShipCountry))
            //    .ForMember(dest => dest.ShipAddress, opt => opt.MapFrom(src => src.ShipAddress)

            //    );
            CreateMap<OrderPutDto, Order>();
            CreateMap<OrderPostDto, Order>();
        }
    }
}
