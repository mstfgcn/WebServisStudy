using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;
using WS.Model.Dtos.Order;


namespace WS.Model.Dtos.Employee
{
    public class EmployeeGetDto : IDto
    {
        [Key]
        public int EmployeeID { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }

        public List<OrderGetDto>? Orders { get; set; }



    }
}
