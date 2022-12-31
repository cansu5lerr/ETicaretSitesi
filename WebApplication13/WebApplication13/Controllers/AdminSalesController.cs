using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using X.PagedList;
namespace WebApplication13.Controllers
{
    public class AdminSalesController : Controller
    {
        private readonly ApplicationDbContext db;
        public AdminSalesController(ApplicationDbContext context)
        {
            db = context;
        }
        public ActionResult Index(int sayfa = 1)

        {

            return View(db.Sales.ToList().ToPagedList(sayfa, 5));
        }
    }
}
