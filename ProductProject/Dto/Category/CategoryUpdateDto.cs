using System.ComponentModel.DataAnnotations;

namespace ProductProject.Dto.Category
{
    public class CategoryUpdateDto
    {
  
        [MaxLength(20)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
    }
}