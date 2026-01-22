using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class OptionReadDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
    }
}
