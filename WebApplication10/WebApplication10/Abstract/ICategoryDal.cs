using WebApplication10.Models;

namespace WebApplication10.Abstract
{
    public interface ICategoryDal
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
        List<Category> ListAllCategories();
        Category GetById(int id);
    }
}
