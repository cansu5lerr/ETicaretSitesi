using Microsoft.AspNetCore.Mvc;
using WebApplication10.Abstract;

namespace WebApplication10.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        public ActionResult Details(int id)
        {
            var details = productRepository.GetById(id);
            return View(details);
        }
    }
}
