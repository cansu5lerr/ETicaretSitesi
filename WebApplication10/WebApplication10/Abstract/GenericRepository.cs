using WebApplication10.Db;

namespace WebApplication10.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        public void Delete(T item)
        {
            using var c = new DataContext();
            c.Remove(item);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new DataContext();
            return c.Set<T>().Find(id);
        }


        public void Insert(T item)
        {
            using var c = new DataContext();
            c.Add(item);
            c.SaveChanges();
        }

        public List<T> List()
        {
            using var c = new DataContext();
            return c.Set<T>().ToList();
        }

        public void Update(T item)
        {
            using var c = new DataContext();
            c.Update(item);
            c.SaveChanges();
        }
    }
}

