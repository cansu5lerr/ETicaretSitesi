using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using WebApplication13.Models;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication13.Controllers
{
    public class ProductController :Controller
    {
        private readonly ApplicationDbContext c;
        public ProductController(ApplicationDbContext context)
        {
            c = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index(int page = 1)
        {
            var values = c.Products.ToList().ToPagedList(page, 5);
            return View(values);
        }
        public ActionResult Create() //Sayfaya getirme islemi
        {
            List<SelectListItem> deger1 = (from i in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View();

        }
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(AddImage p)
        {
            Product w = new Product();
            if (p.Image != null)
            {
                var extension = Path.GetExtension(p.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagesFile/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.Image.CopyTo(stream);
                w.Image = newimagename;

            }
            w.Description = p.Description;
            w.Name = p.Name;
            w.Price = p.Price;
            w.Stock = p.Stock;
            w.Popular = p.Popular;
            w.IsApproved = p.IsApproved;
            w.Quantity = p.Quantity;
            w.CategoryId = p.CategoryId;
            w.Category = p.Category;
            c.Add(w);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = c.Products.Find(id);
            c.Remove(delete);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
        public ActionResult Update(int id)
        {
            List<SelectListItem> deger1 = (from i in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            var update = c.Products.Find(id);
            return View(update);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Update(Product w,AddImage p)
        {

            var extension = Path.GetExtension(p.Image.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImagesFile/", newimagename);
            var stream = new FileStream(location, FileMode.Create);
            p.Image.CopyTo(stream);
            w.Image = newimagename;
            List<SelectListItem> deger1 = (from i in c.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            if (!ModelState.IsValid)
            {
                var update = c.Products.Find(w.Id);
                update.Description = w.Description;
                update.Name = w.Name;
                update.IsApproved = w.IsApproved;
                update.Popular = w.Popular;
                update.Price = w.Price;
                update.Stock = w.Stock;
                update.Image = w.Image;
                update.CategoryId = w.CategoryId;
                c.Update(update);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            return View ("Hata");
        }
    }
}
