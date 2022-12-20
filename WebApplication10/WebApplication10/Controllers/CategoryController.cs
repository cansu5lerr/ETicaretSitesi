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
using System.ComponentModel;

namespace WebApplication10.Controllers
{
    public class CategoryController :Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        ProductRepository productRepository = new ProductRepository();
        DataContext db = new DataContext();
        public PartialViewResult CategoryList()
        {
            return PartialView(categoryRepository.List());

        }
        public ActionResult Details(int id)
        {
            var cat = categoryRepository.CategoryDetails(id);
            return View(cat);
        }
    }
}
