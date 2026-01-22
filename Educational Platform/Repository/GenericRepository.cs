using Educational_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace Educational_Platform.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext appDbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            dbSet = this.appDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public List<T> GetAll()
        {
            var list = dbSet.AsNoTracking().ToList();
            return list;
        }

        public T? Details(int id)
        {
            var entity = dbSet.Find(id);
            return entity;
        }

        public void Save()
        {
            appDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T? Details(int id);
        public void Save();
    }
}
