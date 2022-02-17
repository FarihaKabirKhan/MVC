using Evidence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evidence.Controllers
{
    public class HomeController : Controller
    {
        StudentInfoEntities2 db = new StudentInfoEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            var oUser = db.Users.Where(w => w.UserName == user.UserName && w.Password == user.Password).FirstOrDefault();
            if (oUser != null)
            {
                Session["User"] = oUser;
                return RedirectToAction("Index", "Students");
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");


        }
    }
}