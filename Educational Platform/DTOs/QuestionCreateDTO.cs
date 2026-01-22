using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class QuestionCreateDTO
    {
        [Required]
        public string Text { get; set; }
        [Required]
        [Range(1, 4)]
        public int CorrectAnswerOption { get; set; }
        public int ExamId { get; set; }
        [Required]
        public List<OptionCreateDTO> Options { get; set; }
    }
}
