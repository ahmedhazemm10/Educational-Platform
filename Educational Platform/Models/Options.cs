using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.Models
{
    public class Options
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
        [Range(1 , 4)]
        public int Order { get; set; }
        public Question Question { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
    }
}