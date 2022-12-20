using WebApplication10.Abstract;
using WebApplication10.Db;
using WebApplication10.Models;

namespace WebApplication10.Repository
{
    public class CategoryRepository : ICategoryDal
    {
        DataContext c = new DataContext();
        public void AddCategory(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }

        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> ListAllCategories()
        {
            return c.Categories.ToList();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
