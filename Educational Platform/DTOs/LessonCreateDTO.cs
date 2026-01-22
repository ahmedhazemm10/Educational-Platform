using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class LessonCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string URL { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Order { get; set; }
        [Range(1, int.MaxValue)]
        public int DurationMinutes { get; set; }
        public int CourseId { get; set; }
    }
}
