using Educational_Platform.DTOs;
using Educational_Platform.Models;

namespace Educational_Platform.Repository
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public List<Lesson> GetLessonsByCourseId(int courseId)
        {
            return appDbContext.Lessons.Where(l => l.CourseId == courseId).ToList();
        }
    }
    public interface ILessonRepository : IGenericRepository<Lesson>
    {
        public List<Lesson> GetLessonsByCourseId(int courseId);
    }
}
