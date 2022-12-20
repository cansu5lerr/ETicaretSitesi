using WebApplication10.Models;

namespace WebApplication10.Abstract
{
    public interface IUrun
    {
        List<Product> ListAllProduct();
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        Product GetById(int id);
        List<Product> ListAllProducts();
    }
}
