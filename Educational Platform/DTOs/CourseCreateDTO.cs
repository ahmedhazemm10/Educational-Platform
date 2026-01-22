using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class CourseCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
