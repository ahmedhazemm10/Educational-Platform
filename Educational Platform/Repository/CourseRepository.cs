using Educational_Platform.DTOs;
using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public int NumOfCourseStudents(int id)
        {
            return appDbContext.Enrollments.Where(e => e.CourseId == id && e.Status == Status.Active).Count();
        }

        public List<Course> Search(string title)
        {
            return appDbContext.Courses.Where(c => c.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
    public interface ICourseRepository : IGenericRepository<Course>
    {
        public List<Course> Search(string title);
        public int NumOfCourseStudents(int id);
    }
}
