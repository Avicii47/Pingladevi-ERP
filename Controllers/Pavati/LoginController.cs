using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Pingladevi.Data;
using Pingladevi.Models;

namespace Pingladevi.Controllers.Pavati
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }
        public ActionResult LoginIN(Loginmodel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "123")
                {
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }
            }
            return View("..\\Login\\Index", model);
        }
        public ActionResult UserDashBoard()
        {
            //return View("..\\Login\\Index");
            return View("..\\Pavati\\DashboardIndex");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }
    }
}