using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.DTOs
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Governorate { get; set; }
    }
}
