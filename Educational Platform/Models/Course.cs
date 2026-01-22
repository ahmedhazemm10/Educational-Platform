using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public Exam Exam { get; set; }
    }
}
