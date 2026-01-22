using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class SubmitExamDTO
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        [Range(1,4)]
        public int StudentAnswer {  get; set; }
    }
}
