using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class StudentDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [Range(1,3)]
        public int Level { get; set; }
        [MaxLength(100)]
        public string Governorate { get; set; }
    }
}
