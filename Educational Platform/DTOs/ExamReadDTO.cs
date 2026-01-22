using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class ExamReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double TotalMarks { get; set; }
        public int CourseId { get; set; }
    }
}
