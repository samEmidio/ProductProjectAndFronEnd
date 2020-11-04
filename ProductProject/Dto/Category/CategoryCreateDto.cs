using System.ComponentModel.DataAnnotations;

namespace ProductProject.Dto.Category
{
    public class CategoryCreateDto
    {

        [Required]
        [MaxLength(20)]
        public string name { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
    }
}