using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Entities
{
    public class Employee : IEntity
    {

        [Key]
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? HomePhone { get; set; }
        public string? Notes { get; set; }


        public List<Order>? Orders { get; set; }






    }
}
