using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Db;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebApplication10.Controllers
{
    public class AccountController :Controller
    {
        DataContext db = new DataContext();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(User data)
        {
            var bilgiler = db.Users.FirstOrDefault(x => x.Email == data.Email && x.Password == data.Password);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, data.Name)
                    };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
                //FormsAuthentication.SetAuthCookie(bilgiler.Email, false);

                //Session["Mail"] = bilgiler.Email.ToString();
                //Session["Ad"] = bilgiler.Name.ToString();
                //Session["Soyad"] = bilgiler.Surname.ToString();
                //return RedirectToAction("Index", "Home");

            }


            ViewBag.Hata = "Kullanıcı Adı Veya Şifreniz Yanlış";
            return View(data);
        }
        //[HttpPost]
        //public ActionResult Register(User data)
        //{
        //    db.Users.Add(data);
        //    data.Role = "User";

        //    db.SaveChanges();

        //    ViewBag.register = "Kayıt işlemi başarılı giriş yapabilirsiniz.";
        //    return RedirectToAction("Login");

        //}

        //public ActionResult LogOut()
        //{
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
