using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ProductProject.Model;

namespace ProductProject.Dto.Product
{
    public class ProductUpdateDto
    {
     
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        public IFormFileCollection picturesForm { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }
        // public Model.Category category { get; set; }
    }
}