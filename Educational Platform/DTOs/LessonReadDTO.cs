using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class LessonReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int Order { get; set; }
        public int DurationMinutes { get; set; }
        public int CourseId { get; set; }
    }
}
