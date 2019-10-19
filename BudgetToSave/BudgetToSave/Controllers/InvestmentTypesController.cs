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
    public class InvestmentTypesController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: InvestmentTypes
        public ActionResult InvestmentType()
        {
            return View(db.InvestmentTypes.ToList());
        }

        // GET: InvestmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentType investmentType = db.InvestmentTypes.Find(id);
            if (investmentType == null)
            {
                return HttpNotFound();
            }
            return View(investmentType);
        }

        // GET: InvestmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvestmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvestmentTypeID,Description")] InvestmentType investmentType)
        {
            if (ModelState.IsValid)
            {
                db.InvestmentTypes.Add(investmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investmentType);
        }

        // GET: InvestmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentType investmentType = db.InvestmentTypes.Find(id);
            if (investmentType == null)
            {
                return HttpNotFound();
            }
            return View(investmentType);
        }

        // POST: InvestmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvestmentTypeID,Description")] InvestmentType investmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investmentType);
        }

        // GET: InvestmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestmentType investmentType = db.InvestmentTypes.Find(id);
            if (investmentType == null)
            {
                return HttpNotFound();
            }
            return View(investmentType);
        }

        // POST: InvestmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentType investmentType = db.InvestmentTypes.Find(id);
            db.InvestmentTypes.Remove(investmentType);
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
