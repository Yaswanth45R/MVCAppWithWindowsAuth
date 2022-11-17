using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAppWithWindowsAuth.Models;

namespace MVCAppWithWindowsAuth.Controllers
{
    public class AccountController : Controller
    {
      MVCDBEntities dc = new MVCDBEntities();
        public ViewResult Register()
        {
            return View();  
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                User user = new User { UserId = model.UserId, Name = model.Name,Password = model.Password,Email=model.Email,Mobile=model.Mobile,Status=true };
                dc.Users.Add(user);
                dc.SaveChanges();
                return RedirectToAction("Login");
            }
        }
        public ViewResult Login()
        {
            return View();  
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var user = from u in dc.Users where u.UserId == model.UserId && u.Password == model.Password && u.Status == true select u;
                if (user.Count()==0)
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
                }
                else
                {
                    Session["UserKey"] = Guid.NewGuid();
                    return RedirectToAction("Index","Home");
                }
            }
        }
    }
}