using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Score { get; set; }
        public Student Student { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Exam Exam { get; set; }  
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
    }
}
