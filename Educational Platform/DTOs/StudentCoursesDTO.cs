using Educational_Platform.Models;

namespace Educational_Platform.DTOs
{
    public class StudentCoursesDTO
    {
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
        public DateTime EnrollAt { get; set; }
        public Status Status { get; set; }
    }
}
