using Educational_Platform.Models;

namespace Educational_Platform.Repository
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Enrollment? GetEnrollment(Enrollment enrollment)
        {
            return appDbContext.Enrollments.FirstOrDefault(e => e.CourseId == enrollment.CourseId
            && e.StudentId == enrollment.StudentId);
        }
    }
    public interface IEnrollmentRepository : IGenericRepository<Enrollment>
    {
        public Enrollment? GetEnrollment(Enrollment enrollment);
    }
}
