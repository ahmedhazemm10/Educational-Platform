using Educational_Platform.Models;

namespace Educational_Platform.Repository
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Exam? GetCourseExam(int courseId)
        {
            return appDbContext.Exams.FirstOrDefault(e => e.CourseId == courseId);
        }
    }
    public interface IExamRepository : IGenericRepository<Exam>
    {
        public Exam? GetCourseExam(int courseId);
    }
}
