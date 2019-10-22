using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetToSave.Models;

namespace BudgetToSave.Controllers
{
    public class CreateUsersController : Controller
    {
        // GET: CreateUsers
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            BudgetDBEntities db = new BudgetDBEntities();
            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
            string message = string.Empty;
            switch (user.UserID)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + user.UserID.ToString();
                    break;
            }
            ViewBag.Message = message;

            return View(user);
        }
    }
}
    
