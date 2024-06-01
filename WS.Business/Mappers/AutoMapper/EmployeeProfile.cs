using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WS.Model.Dtos.Employee;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.Business.Mappers.AutoMapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>();
            CreateMap<Order,OrderGetDto>();
            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployePutDto, Employee>();
        }
    }
}

