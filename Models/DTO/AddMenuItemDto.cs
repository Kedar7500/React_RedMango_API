using System.ComponentModel.DataAnnotations;

namespace RedMango_API.Models.DTO
{
    public class AddMenuItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
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
