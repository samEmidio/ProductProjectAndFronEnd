using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductProject.Model
{
    public class Picture
    {
        [Key]
        public int id { get; set; }
        public string path { get; set; }
        public int productId { get; set; }
        [JsonIgnore]
        public Product product { get; set; }
    }
}