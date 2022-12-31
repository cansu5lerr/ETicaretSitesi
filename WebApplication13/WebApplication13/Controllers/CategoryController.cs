using Microsoft.AspNetCore.Mvc;
using WebApplication13.Data;
using WebApplication13.Models;


namespace WebApplication13.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext c;
        public CategoryController(ApplicationDbContext context)
        {
            c = context;
        }
        public ActionResult Create()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                c.Add(category);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            return View();
        }
        public ActionResult Delete(int id)
        {     
            var delete = c.Categories.Find(id);
            c.Remove(delete);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var update = c.Categories.Find(id);
            return View(update);
        }
     
        [HttpPost]
        public ActionResult Update(Category p)
        {
            if (!ModelState.IsValid)
            {
                var update = c.Categories.Find(p.Id);
                update.Name = p.Name;
                update.Description = p.Description;
                c.Update(update);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Bir hata oluştu");
            return View();
        }
        public Category GetById(int id)
        {
            return c.Categories.Find(id);
        }

        public ActionResult Index()
        {
            var d = c.Categories.ToList();
            return View(d);
        }

        public void UpdateCategory(Category category)
        {

            c.Update(category);
            c.SaveChanges();
        }


    }
}
