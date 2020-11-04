using System.Collections.Generic;
using ProductProject.Model;

namespace ProductProject.Dto.Product
{
    public class ProductReadDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Picture> pictures { get; set; }
        public double price { get; set; }
        public Model.Category category { get; set; }
    }
}