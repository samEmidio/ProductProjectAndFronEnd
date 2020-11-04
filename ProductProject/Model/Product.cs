using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductProject.Model
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        public double price { get; set; }
        [Required]
        public int categoryId { get; set; }
        public Category category { get; set; }
        public List<Picture> pictures { get; set; }
    }
}