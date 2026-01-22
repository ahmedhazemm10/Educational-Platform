using Educational_Platform.Models;

namespace Educational_Platform.Repository
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        public GradeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
    public interface IGradeRepository : IGenericRepository<Grade>
    {
    }
}
