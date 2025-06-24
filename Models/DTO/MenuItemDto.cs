using System.ComponentModel.DataAnnotations;

namespace RedMango_API.Models.DTO
{
    public class MenuItemDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public string SpecialTag { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public double Price { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
