using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ProductProject.Model;

namespace ProductProject.Dto.Product
{
    public class ProductCreateDto
    {

        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        public IFormFileCollection picturesForm { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int categoryId { get; set; }
        // public Model.Category category { get; set; }
    }
}