using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class EnrollmentDTO
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
