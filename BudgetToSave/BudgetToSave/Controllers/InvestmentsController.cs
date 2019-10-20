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
        public ActionResult Create([Bind(Include = "InvestmentID,Amount,NumOfYears,TotalInvest,InterestRate,InterestPeriodID,InterestTypeID,InvestmentTypeID,Date")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Investments.Add(investment);
                db.SaveChanges();
                return RedirectToAction("Investment");
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
        public ActionResult Edit([Bind(Include = "InvestmentID,Amount,NumOfYears,TotalInvest,InterestRate,InterestPeriodID,InterestTypeID,InvestmentTypeID,Date")] Investment investment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Investment");
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
            return RedirectToAction("Investment");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult InvestmentCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InvestmentCalculator(double amount, double interestrate, int interesttype, int interestperiod, int investmenttype, double numofyears)
        {
            double Mamount = amount;                //investamount
            double Minterestrate = interestrate;    //interestrate
            int Minteresttype = interesttype;       //interesttype table
            int Minterestperiod = interestperiod;   //quarterly yearly...
            int Minvestmenttype = investmenttype;   //investtype table
            double Mnumofyears = numofyears;        //numofyears

            if (Minteresttype == 1)
            {
                if (Minterestperiod == 1)
                {
                    double brackets = (1 + (Minterestrate * 0.01));
                    double exponent = numofyears * 1;
                    double power = Math.Pow(brackets, exponent);

                    double compoundinvestment = amount * power;

                    ViewBag.Message = compoundinvestment;
                }
                else if (Minterestperiod == 2)
                {
                    double brackets = (1 + ((Minterestrate * 0.01) * 0.5));
                    double exponent = numofyears * 2;
                    double power = Math.Pow(brackets, exponent);

                    double compoundinvestment = amount * power;

                    ViewBag.Message = compoundinvestment;
                }
                else if (Minterestperiod == 3)
                {
                    double brackets = (1 + ((Minterestrate * 0.01) * 0.25));
                    double exponent = numofyears * 4;
                    double power = Math.Pow(brackets, exponent);

                    double compoundinvestment = amount * power;

                    ViewBag.Message = compoundinvestment;
                }
                else if (Minterestperiod == 4)
                {
                    double brackets = (1 + ((Minterestrate * 0.01) * 0.083333333));
                    double exponent = numofyears * 12;
                    double power = Math.Pow(brackets, exponent);

                    double compoundinvestment = amount * power;

                    ViewBag.Message = compoundinvestment;
                }
            }
            else if (Minteresttype == 2)
            {
                if (Minterestperiod == 1)
                {
                    double finalinvestment = (amount * (1 + (Minterestrate / 100) * Mnumofyears));

                    ViewBag.Message = finalinvestment;
                }
                else if (Minterestperiod == 2)
                {
                    double finalinvestment = (amount * (1 + ((Minterestrate * 0.01) * 0.5) * (Mnumofyears * 2)));

                    ViewBag.Message = finalinvestment;
                }
                else if (Minterestperiod == 3)
                {
                    double finalinvestment = (amount * (1 + ((Minterestrate * 0.01) * 0.25) * (Mnumofyears * 4)));

                    ViewBag.Message = finalinvestment;
                }
                else if (Minterestperiod == 4)
                {
                    double finalinvestment = (amount * (1 + ((Minterestrate * 0.01) * 0.08333) * (Mnumofyears * 12)));

                    ViewBag.Message = finalinvestment;
                }
            }

            return View();
        }
    }
}
