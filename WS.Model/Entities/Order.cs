using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Dtos.Employee;

namespace WS.Model.Entities
{
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public int? EmployeeId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; } //sipariş tarihi
        public DateTime? RequiredDate { get; set; } //istenen tarih
        public DateTime? ShippedDate { get; set; } //sevk tarihi

        public decimal Freight { get; set; }
        public int? ShipVia { get; set; } //aracı kurum 
        public string? ShipName { get; set; } // sevk edilen isim
        public string? ShipCity { get; set; } //sevk edilen şehir
        public string? ShipCountry { get; set; } // sevk edilen ülke
        public string? ShipAddress { get; set; }  // sevk edilen adres


        //Navigation Property
        public Employee? Employee { get; set; }
        //public Customer? Customer { get; set; }
        //public Shippers Shippers { get; set; }

        


    }
}
