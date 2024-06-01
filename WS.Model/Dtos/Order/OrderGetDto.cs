using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Model.Dtos.Order
{
    public class OrderGetDto:IDto
    {
        [Key]
        public int OrderId { get; set; }
        //public int EmployeeID { get; set; }
        //public string? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; } //sipariş tarihi
        public DateTime? RequiredDate { get; set; } //istenen tarih
        public DateTime? ShippedDate { get; set; } //sevk tarihi

        //public int? ShipVia { get; set; } //aracı kurum 

        public decimal Freight { get; set; } // nakliye ücreti
        public string? ShipName { get; set; } // sevk edilen isim
        public string? ShipCity { get; set; } //sevk edilen şehir
        public string? ShipCountry { get; set; } // sevk edilen ülke
        public string? ShipAddress { get; set; }  // sevk edilen adres



        public EmployeeGetDto Employee { get; set; }
        //public string? CustomerName { get; set; }
        //public string? ShipViaName {  get; set; }



    }
}
