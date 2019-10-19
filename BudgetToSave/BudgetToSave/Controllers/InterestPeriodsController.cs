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
    public class InterestPeriodsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: InterestPeriods
        public ActionResult InterestPeriod()
        {
            return View(db.InterestPeriods.ToList());
        }

        // GET: InterestPeriods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestPeriod interestPeriod = db.InterestPeriods.Find(id);
            if (interestPeriod == null)
            {
                return HttpNotFound();
            }
            return View(interestPeriod);
        }

        // GET: InterestPeriods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterestPeriods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterestPeriodID,Description")] InterestPeriod interestPeriod)
        {
            if (ModelState.IsValid)
            {
                db.InterestPeriods.Add(interestPeriod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interestPeriod);
        }

        // GET: InterestPeriods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestPeriod interestPeriod = db.InterestPeriods.Find(id);
            if (interestPeriod == null)
            {
                return HttpNotFound();
            }
            return View(interestPeriod);
        }

        // POST: InterestPeriods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestPeriodID,Description")] InterestPeriod interestPeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interestPeriod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interestPeriod);
        }

        // GET: InterestPeriods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestPeriod interestPeriod = db.InterestPeriods.Find(id);
            if (interestPeriod == null)
            {
                return HttpNotFound();
            }
            return View(interestPeriod);
        }

        // POST: InterestPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterestPeriod interestPeriod = db.InterestPeriods.Find(id);
            db.InterestPeriods.Remove(interestPeriod);
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
