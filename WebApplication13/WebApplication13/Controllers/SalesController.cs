using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication13.Data;
using WebApplication13.Models;
using X.PagedList;
namespace WebApplication13.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext db;
        public SalesController(ApplicationDbContext context)
        {
            db = context;
        }
        public ActionResult Index(int sayfa = 1)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == kullaniciadi);
                var model = db.Sales.Where(x => x.UserId == kullanici.Id).ToList().ToPagedList(sayfa, 5);
                return View(model);
            }
            return View("Hata");
        }

        public ActionResult Buy(int id)
        {
            List<SelectListItem> deger1 = (from i in db.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            var model = db.Carts.FirstOrDefault(x => x.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Buy2(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Carts.FirstOrDefault(x => x.Id == id);
                    var satis = new Sales
                    {
                        UserId = model.UserId,
                        ProductId = model.ProductId,
                        Quantity = model.Quantity,                      
                        Price = model.Price,
                        Date = model.Date,

                    };
                    db.Carts.Remove(model);
                    db.Sales.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satın Alma İşlemi Başarılı Bir Şekilde Gerçekleşmiştir";
                }
            }
            catch (Exception)
            {

                ViewBag.islem = "Satın Alma İşlemi Başarısız ";
            }

            return View("islem");

        }

    }
}
