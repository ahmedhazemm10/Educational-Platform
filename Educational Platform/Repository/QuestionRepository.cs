using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public List<Question> ExamQuestions(int examId)
        {
            return appDbContext.Questions.Include(q => q.Options).Where(q => q.ExamId == examId).ToList();
        }

        public Question? GetById(int id)
        {
            return appDbContext.Questions.Include(q => q.Options).FirstOrDefault(q => q.Id == id);
        }
    }
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        public List<Question> ExamQuestions(int examId);
        public Question? GetById(int id);
    }
}
