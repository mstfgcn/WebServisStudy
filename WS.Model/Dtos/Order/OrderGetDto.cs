using Infrastructure.Model;

namespace WS.Model.Dtos.Order
{
    public class OrderGetDto:IDto
    {
        public int OrderId { get; set; }
        //public int EmployeeId { get; set; }
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


        //Maplenirken ayarlanıcak
        public string? EmployeeName { get; set; }
        public string? CustomerName { get; set; }
        public string? ShipViaName {  get; set; }

        

    }
}
