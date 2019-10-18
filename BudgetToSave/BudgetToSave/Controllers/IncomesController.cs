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
    public class IncomesController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: Incomes
        public ActionResult Index()
        {
            var incomes = db.Incomes.Include(i => i.IncomeType);
            return View(incomes.ToList());
        }

        // GET: Incomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // GET: Incomes/Create
        public ActionResult Create()
        {
            ViewBag.IncomeTypeID = new SelectList(db.IncomeTypes, "IncomeTypeID", "Description");
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomeID,Date,Amount,IncomeTypeID")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IncomeTypeID = new SelectList(db.IncomeTypes, "IncomeTypeID", "Description", income.IncomeTypeID);
            return View(income);
        }

        // GET: Incomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            ViewBag.IncomeTypeID = new SelectList(db.IncomeTypes, "IncomeTypeID", "Description", income.IncomeTypeID);
            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomeID,Date,Amount,IncomeTypeID")] Income income)
        {
            if (ModelState.IsValid)
            {
                db.Entry(income).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IncomeTypeID = new SelectList(db.IncomeTypes, "IncomeTypeID", "Description", income.IncomeTypeID);
            return View(income);
        }

        // GET: Incomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Income income = db.Incomes.Find(id);
            if (income == null)
            {
                return HttpNotFound();
            }
            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Income income = db.Incomes.Find(id);
            db.Incomes.Remove(income);
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
