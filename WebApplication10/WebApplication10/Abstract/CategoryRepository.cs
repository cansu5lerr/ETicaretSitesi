using WebApplication10.Db;
using WebApplication10.Models;

namespace WebApplication10.Abstract
{
    public class CategoryRepository : GenericRepository<Category>
    {
        DataContext db = new DataContext();
        public List<Product> CategoryDetails(int id)
        {
            return db.Products.Where(x => x.CategoryId == id).ToList();
        }
    }
}
