using Infrastructure.Model;
using WS.Model.Dtos.Product;

namespace WS.Model.Dtos.Category
{
    public class CategoryGetDto:IDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }


        //nav
        public List<ProductGetDto>? Products { get; set; }
    }
}
