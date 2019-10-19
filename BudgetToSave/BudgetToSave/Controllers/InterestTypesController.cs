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
    public class InterestTypesController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: InterestTypes
        public ActionResult InterestType()
        {
            return View(db.InterestTypes.ToList());
        }

        // GET: InterestTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestType interestType = db.InterestTypes.Find(id);
            if (interestType == null)
            {
                return HttpNotFound();
            }
            return View(interestType);
        }

        // GET: InterestTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InterestTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterestTypeID,Description")] InterestType interestType)
        {
            if (ModelState.IsValid)
            {
                db.InterestTypes.Add(interestType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(interestType);
        }

        // GET: InterestTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestType interestType = db.InterestTypes.Find(id);
            if (interestType == null)
            {
                return HttpNotFound();
            }
            return View(interestType);
        }

        // POST: InterestTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterestTypeID,Description")] InterestType interestType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(interestType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(interestType);
        }

        // GET: InterestTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InterestType interestType = db.InterestTypes.Find(id);
            if (interestType == null)
            {
                return HttpNotFound();
            }
            return View(interestType);
        }

        // POST: InterestTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InterestType interestType = db.InterestTypes.Find(id);
            db.InterestTypes.Remove(interestType);
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
