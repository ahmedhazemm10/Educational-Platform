using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollAt {  get; set; } = DateTime.Now;
        [Required]
        public Status Status {  get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Course Course { get; set; }
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
    }
}
