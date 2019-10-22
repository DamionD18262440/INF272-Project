using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BudgetToSave.Models;

namespace BudgetToSave.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(User user)
        {
            BudgetDBEntities db = new BudgetDBEntities();
            int? userID = db.ValidateUser(user.UserUseName, user.UserPassword).FirstOrDefault();

            string message = string.Empty;
            switch (userID.Value)
            {
                case -1:
                    message = "Username and/or password is incorrect.";
                    break;
                case -2:
                    return RedirectToAction("Welcome");
                default:

                    return RedirectToAction("Welcome");
            }

            ViewBag.Message = message;
            return View(user);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Logoutt()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}