using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetToSave.Models;

namespace BudgetToSave.Controllers
{
    public class UsersController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: Users
        public ActionResult Users()
        {
            var users = db.Users.Include(u => u.BudgetLimit).Include(u => u.Donation).Include(u => u.Income).Include(u => u.Investment).Include(u => u.MonthlySpending).Include(u => u.NetWorth).Include(u => u.UserType);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.BudgetLimitID = new SelectList(db.BudgetLimits, "BudgetLimitID", "BudgetLimitID");
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID");
            ViewBag.IncomeID = new SelectList(db.Incomes, "IncomeID", "IncomeID");
            ViewBag.InvestmentID = new SelectList(db.Investments, "InvestmentID", "InvestmentID");
            ViewBag.MonthlySpendingID = new SelectList(db.MonthlySpendings, "MonthlySpendingID", "MonthlySpendingID");
            ViewBag.NetWorthID = new SelectList(db.NetWorths, "NetWorthID", "NetWorthID");
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "Description");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserSurname,UserUseName,UserPassword,UserTypeID,BudgetLimitID,MonthlySpendingID,NetWorthID,IncomeID,InvestmentID,DonationID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetLimitID = new SelectList(db.BudgetLimits, "BudgetLimitID", "BudgetLimitID", user.BudgetLimitID);
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", user.DonationID);
            ViewBag.IncomeID = new SelectList(db.Incomes, "IncomeID", "IncomeID", user.IncomeID);
            ViewBag.InvestmentID = new SelectList(db.Investments, "InvestmentID", "InvestmentID", user.InvestmentID);
            ViewBag.MonthlySpendingID = new SelectList(db.MonthlySpendings, "MonthlySpendingID", "MonthlySpendingID", user.MonthlySpendingID);
            ViewBag.NetWorthID = new SelectList(db.NetWorths, "NetWorthID", "NetWorthID", user.NetWorthID);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserTypeID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetLimitID = new SelectList(db.BudgetLimits, "BudgetLimitID", "BudgetLimitID", user.BudgetLimitID);
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", user.DonationID);
            ViewBag.IncomeID = new SelectList(db.Incomes, "IncomeID", "IncomeID", user.IncomeID);
            ViewBag.InvestmentID = new SelectList(db.Investments, "InvestmentID", "InvestmentID", user.InvestmentID);
            ViewBag.MonthlySpendingID = new SelectList(db.MonthlySpendings, "MonthlySpendingID", "MonthlySpendingID", user.MonthlySpendingID);
            ViewBag.NetWorthID = new SelectList(db.NetWorths, "NetWorthID", "NetWorthID", user.NetWorthID);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserTypeID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserSurname,UserUseName,UserPassword,UserTypeID,BudgetLimitID,MonthlySpendingID,NetWorthID,IncomeID,InvestmentID,DonationID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetLimitID = new SelectList(db.BudgetLimits, "BudgetLimitID", "BudgetLimitID", user.BudgetLimitID);
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", user.DonationID);
            ViewBag.IncomeID = new SelectList(db.Incomes, "IncomeID", "IncomeID", user.IncomeID);
            ViewBag.InvestmentID = new SelectList(db.Investments, "InvestmentID", "InvestmentID", user.InvestmentID);
            ViewBag.MonthlySpendingID = new SelectList(db.MonthlySpendings, "MonthlySpendingID", "MonthlySpendingID", user.MonthlySpendingID);
            ViewBag.NetWorthID = new SelectList(db.NetWorths, "NetWorthID", "NetWorthID", user.NetWorthID);
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "UserTypeID", "Description", user.UserTypeID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
