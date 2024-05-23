using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.Order;
using WS.Model.Entities;

namespace WS.Model.Dtos.Employee
{
    public class EmployeeGetDto:IDto
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
       

        //sor ???
        public List<OrderGetDto> Orders { get; set; }
      
        

    }
}
