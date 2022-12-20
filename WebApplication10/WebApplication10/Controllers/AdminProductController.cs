using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using WebApplication10.Abstract;
using WebApplication10.Db;
using WebApplication10.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using X.PagedList;
using X.PagedList.Mvc;

namespace WebApplication10.Controllers
{
    public class AdminProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public IActionResult Index(int page=1)
        {
            var values = productRepository.List().ToPagedList(page,5);
            return View(values);
        }
        public ActionResult Create() //Sayfaya getirme islemi
        {
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();
            ViewBag.ktgr = deger1;
            return View();

        }
        //public async Task<IActionResult> Create (AddImage p, IFormFile file)
        //{
        //    Product w = new Product();
        //    if (p.Image != null)
        //    {
        //        var extension = Path.GetExtension(p.Image.FileName);
        //        var newimagename = Guid.NewGuid() + extension;
        //        var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ImagesFile/{newimagename}");
        //        var stream1 = new FileStream(location, FileMode.Create);
        //        var stream = new FileStream(location, FileMode.Create);

        //        await file.CopyToAsync(stream);
        //        p.Image.CopyTo(stream);
        //        w.Image = newimagename;

        //    }
        //    w.Description = p.Description;
        //    w.Name = p.Name;
        //    w.Price = p.Price;
        //    w.Stock = p.Stock;
        //    w.Popular = p.Popular;
        //    w.IsApproved = p.IsApproved;
        //    w.Quantity = p.Quantity;
        //    w.CategoryId = p.CategoryId;
        //    w.Category = p.Category;
        //    productRepository.Insert(w);
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public async Task<IActionResult> UploadImage(IFormFile file)
        //{
        //    if (file != null)
        //    {
        //        string imageExtension = Path.GetExtension(file.FileName);

        //        string imageName = Guid.NewGuid() + imageExtension;

        //        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/ImagesFile/{imageName}");

        //        using var stream = new FileStream(path, FileMode.Create);

        //        await file.CopyToAsync(stream);
        //    }

        //    return RedirectToAction("UploadImage");
        //}
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
            productRepository.Insert(w);
            return RedirectToAction("Index");
        }
        public ActionResult Delete( int id)
        {
            var delete= productRepository.GetById(id);
            productRepository.Delete(delete);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var update = productRepository.GetById(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(Product data)
        {
            var update = productRepository.GetById(data.Id);
            update.Description = data.Description;
            update.Name = data.Name;
            update.IsApproved = data.IsApproved;
            update.Popular = data.Popular;
            update.Price = data.Price;
            update.Stock = data.Stock;
            update.CategoryId=data.CategoryId; 
            productRepository.Update(data);   
            return RedirectToAction("Index");
        }

    }

}
