﻿using Infrastructure.Model;
using WS.Model.Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace WS.Model.Dtos.Category
{
    public class CategoryGetDto:IDto
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? PicturePath { get; set; }
        public string Base64Picture { get; set; }
        public bool? IsActive { get; set; }

        //nav
        public List<ProductGetDto>? Products { get; set; }
    }
}
