using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Model.Dtos.Category
{
    public class CategoryPutDto:IDto
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

    }
}
