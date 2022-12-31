using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        private readonly ApplicationDbContext db;
        public CartController(ApplicationDbContext context)
        {
            db = context;
        }
        public ActionResult Index(decimal? Tutar) //listele ve toplam fiyatı gönder

        {
            List<SelectListItem> deger1 = (from i in db.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                var kullanici = db.Users.FirstOrDefault(x => x.Email == username);
                var model = db.Carts.Where(x => x.UserId== kullanici.Id).ToList();
                var kid = db.Carts.FirstOrDefault(x => x.UserId == kullanici.Id);

                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmamaktadır";
                    }
                    else if (kid != null)
                    {
                        Tutar = db.Carts.Where(x => x.UserId == kid.UserId).Sum(x => x.Product.Price * x.Quantity);
                        ViewBag.Tutar = "Toplam Tutar =" + Tutar + "TL";
                    }
                    return View(model);
                }
            }
            return View("Hata");

        }

        public ActionResult AddCart(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                var kullaniciadi = User.Identity.Name;
                var model = db.Users.FirstOrDefault(x => x.Email == kullaniciadi);
                var u = db.Products.Find(id);
                u.Stock--;
                var sepet = db.Carts.FirstOrDefault(x => x.UserId == model.Id && x.ProductId == id);
                if (model != null)
                {
                    if (sepet != null)
                    {
                        sepet.Quantity++;
                        sepet.Price = u.Price * sepet.Quantity;
                        db.SaveChanges();
                        return RedirectToAction("Index", "Cart");
                    }
                    var s = new Cart
                    {
                        UserId= model.Id,
                        ProductId = u.Id,
                        Quantity = 1,
                        Price = u.Price,
                        Date = DateTime.Now


                    };
                    db.Carts.Add(s);
                   
                    db.SaveChanges();
                    return RedirectToAction("Index", "Cart");

                }
                return View();



            }
            return View("Hata");
        }

        public ActionResult TotalCount(int? count)
        {
            if (User.Identity.IsAuthenticated)
            {

                var model = db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
                count = db.Carts.Where(x => x.UserId== model.Id).Count();
                ViewBag.Count = count;
                if (count == 0)
                {
                    ViewBag.Count = "";
                }

                return PartialView();
            }
            return View();
        }

        public ActionResult arttir(int id)
        {
            var model = db.Carts.Find(id);
            model.Quantity++;
            model.Price = model.Price * model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        public ActionResult azalt(int id)
        {
            var model = db.Carts.Find(id);
            if (model.Quantity == 1)
            {
                db.Carts.Remove(model);
                db.SaveChanges();
            }
            model.Quantity--;
            model.Price = model.Price * model.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }
        public void DinamikMiktar(int id, int miktari)
        {
            var model = db.Carts.Find(id);
            model.Quantity = miktari;
            model.Price = model.Price * model.Quantity;
            db.SaveChanges();

        }

        public ActionResult Delete(int id)
        {
            var sil = db.Carts.Find(id);
            db.Carts.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult DeleteRange()
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciadi = User.Identity.Name;
                var model = db.Users.FirstOrDefault(x => x.Email == kullaniciadi);
                var sil = db.Carts.Where(x => x.UserId== model.Id);
                db.Carts.RemoveRange(sil);
                db.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            return View();
        }

    }
}
