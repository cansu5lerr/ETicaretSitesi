using Microsoft.AspNetCore.Identity;
using WebApplication10.Abstract;
using WebApplication10.Db;
using WebApplication10.Models;

namespace WebApplication10.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Delete(T item)
        {
            using var c = new DataContext();
            c.Remove(item);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            using var c = new DataContext();
            c.Add(item);
            c.SaveChanges();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
