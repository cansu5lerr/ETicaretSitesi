using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;

namespace WebApplication13.Controllers
{
    public class ProductDetay :Controller
    {
        private readonly ApplicationDbContext c;
        public ProductDetay(ApplicationDbContext context)
        {
            c = context;
        }
        public ActionResult Details(int id)
        {
            var details = c.Products.Find(id);
            return View(details);
        }
    }
}
