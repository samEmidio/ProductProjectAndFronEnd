using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductProject.Model
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(20)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        [JsonIgnore]
        public List<Product> product { get; set; }
    }
}