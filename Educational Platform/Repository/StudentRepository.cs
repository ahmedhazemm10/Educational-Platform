using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public Student? GetMyProfile(string id)
        {
            var student = appDbContext.Students.AsNoTracking().FirstOrDefault(s => s.UserId == id);
            return student;
        }

        public List<Enrollment> StudentCourses(int id)
        {
            var courses = appDbContext.Enrollments.AsNoTracking().Include(e => e.Course).Include(e => e.Student).Where(e => e.StudentId == id).ToList();
            return courses;
        }

        public List<Grade> StudentGrades(int id)
        {
            var grades = appDbContext.Grades.AsNoTracking().Include(g => g.Exam).Include(g => g.Student).Where(g => g.StudentId == id).ToList();
            return grades;
        }
    }
    public interface IStudentRepository : IGenericRepository<Student>
    {
        public Student? GetMyProfile(string id);
        public List<Grade> StudentGrades(int id);
        public List<Enrollment> StudentCourses(int id);
    }
}
