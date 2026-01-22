using Educational_Platform.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Platform.DTOs
{
    public class OptionCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
        [Range(1, 4)]
        public int Order { get; set; }
    }
}
