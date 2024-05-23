using Infrastructure.Model;

namespace WS.Model.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? HomePhone { get; set; }
        public string? Notes { get; set; }

        
        public List<Order>? Orders {  get; set; }


        



    }
}
