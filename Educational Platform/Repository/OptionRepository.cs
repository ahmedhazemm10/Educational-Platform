using Educational_Platform.Models;

namespace Educational_Platform.Repository
{
    public class OptionRepository : GenericRepository<Options>, IOptionRepository
    {
        public OptionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public void AddList(List<Options> options)
        {
            appDbContext.Options.AddRange(options);
        }

        public void RemoveList(List<Options> options)
        {
            appDbContext.RemoveRange(options);
        }

        public List<Options> GetByQId(int id)
        {
            return appDbContext.Options.Where(o => o.QuestionId == id).ToList();
        }
    }
    public interface IOptionRepository : IGenericRepository<Options>
    {
        public void AddList(List<Options> options);
        public List<Options> GetByQId(int id);
        public void RemoveList(List<Options> options);
    }
}
