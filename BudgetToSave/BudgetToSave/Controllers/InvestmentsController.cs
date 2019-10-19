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
    public class InvestmentsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: Investments
        public ActionResult Investment()
        {
            var investments = db.Investments.Include(i => i.InterestPeriod).Include(i => i.InterestType).Include(i => i.InvestmentType);
            return View(investments.ToList());
        }

        // GET: Investments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            return View(investment);
        }

        // GET: Investments/Create
        public ActionResult Create()
        {
            ViewBag.InterestPeriodID = new SelectList(db.InterestPeriods, "InterestPeriodID", "Description");
            ViewBag.InterestTypeID = new SelectList(db.InterestTypes, "InterestTypeID", "Description");
            ViewBag.InvestmentTypeID = new SelectList(db.InvestmentTypes, "InvestmentTypeID", "Description");
            return View();
        }

        // POST: Investments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvestmentID,Amount,NumOfYears,TotalInvest,InterestRate,InterestPeriodID,InterestTypeID,InvestmentTypeID")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Investments.Add(investment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InterestPeriodID = new SelectList(db.InterestPeriods, "InterestPeriodID", "Description", investment.InterestPeriodID);
            ViewBag.InterestTypeID = new SelectList(db.InterestTypes, "InterestTypeID", "Description", investment.InterestTypeID);
            ViewBag.InvestmentTypeID = new SelectList(db.InvestmentTypes, "InvestmentTypeID", "Description", investment.InvestmentTypeID);
            return View(investment);
        }

        // GET: Investments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            ViewBag.InterestPeriodID = new SelectList(db.InterestPeriods, "InterestPeriodID", "Description", investment.InterestPeriodID);
            ViewBag.InterestTypeID = new SelectList(db.InterestTypes, "InterestTypeID", "Description", investment.InterestTypeID);
            ViewBag.InvestmentTypeID = new SelectList(db.InvestmentTypes, "InvestmentTypeID", "Description", investment.InvestmentTypeID);
            return View(investment);
        }

        // POST: Investments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvestmentID,Amount,NumOfYears,TotalInvest,InterestRate,InterestPeriodID,InterestTypeID,InvestmentTypeID")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InterestPeriodID = new SelectList(db.InterestPeriods, "InterestPeriodID", "Description", investment.InterestPeriodID);
            ViewBag.InterestTypeID = new SelectList(db.InterestTypes, "InterestTypeID", "Description", investment.InterestTypeID);
            ViewBag.InvestmentTypeID = new SelectList(db.InvestmentTypes, "InvestmentTypeID", "Description", investment.InvestmentTypeID);
            return View(investment);
        }

        // GET: Investments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investment investment = db.Investments.Find(id);
            if (investment == null)
            {
                return HttpNotFound();
            }
            return View(investment);
        }

        // POST: Investments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investment investment = db.Investments.Find(id);
            db.Investments.Remove(investment);
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
