using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class QuestionReadDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<OptionReadDTO> Options { get; set; } = new List<OptionReadDTO>();
    }
}
