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
    public class IncomeTypesController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: IncomeTypes
        public ActionResult IncomeType()
        {
            return View(db.IncomeTypes.ToList());
        }

        // GET: IncomeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeType incomeType = db.IncomeTypes.Find(id);
            if (incomeType == null)
            {
                return HttpNotFound();
            }
            return View(incomeType);
        }

        // GET: IncomeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncomeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IncomeTypeID,Description")] IncomeType incomeType)
        {
            if (ModelState.IsValid)
            {
                db.IncomeTypes.Add(incomeType);
                db.SaveChanges();
                return RedirectToAction("IncomeType");
            }

            return View(incomeType);
        }

        // GET: IncomeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeType incomeType = db.IncomeTypes.Find(id);
            if (incomeType == null)
            {
                return HttpNotFound();
            }
            return View(incomeType);
        }

        // POST: IncomeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IncomeTypeID,Description")] IncomeType incomeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IncomeType");
            }
            return View(incomeType);
        }

        // GET: IncomeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeType incomeType = db.IncomeTypes.Find(id);
            if (incomeType == null)
            {
                return HttpNotFound();
            }
            return View(incomeType);
        }

        // POST: IncomeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomeType incomeType = db.IncomeTypes.Find(id);
            db.IncomeTypes.Remove(incomeType);
            db.SaveChanges();
            return RedirectToAction("IncomeType");
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
