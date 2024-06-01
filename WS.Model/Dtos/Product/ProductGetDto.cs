using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Model.Entities;

namespace WS.Model.Dtos.Product
{
    public class ProductGetDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public string? CategoryName { get; set; }

        
    }
}
