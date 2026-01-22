using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class ExamCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public double TotalMarks { get; set; }
        public int CourseId { get; set; }
    }
}
