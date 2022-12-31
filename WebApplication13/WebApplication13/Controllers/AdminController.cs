using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication13.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
