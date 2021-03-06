﻿using System;
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
    public class BudgetLimitsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: BudgetLimits
        public ActionResult Index()
        {
            return View(db.BudgetLimits.ToList());
        }

        // GET: BudgetLimits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetLimit budgetLimit = db.BudgetLimits.Find(id);
            if (budgetLimit == null)
            {
                return HttpNotFound();
            }
            return View(budgetLimit);
        }

        // GET: BudgetLimits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetLimits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudgetLimitID,FoodLimit,ClothesLimit,AlcoholLimit,OtherLimit")] BudgetLimit budgetLimit)
        {
            if (ModelState.IsValid)
            {
                db.BudgetLimits.Add(budgetLimit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetLimit);
        }

        // GET: BudgetLimits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetLimit budgetLimit = db.BudgetLimits.Find(id);
            if (budgetLimit == null)
            {
                return HttpNotFound();
            }
            return View(budgetLimit);
        }

        // POST: BudgetLimits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudgetLimitID,FoodLimit,ClothesLimit,AlcoholLimit,OtherLimit")] BudgetLimit budgetLimit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetLimit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetLimit);
        }

        // GET: BudgetLimits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetLimit budgetLimit = db.BudgetLimits.Find(id);
            if (budgetLimit == null)
            {
                return HttpNotFound();
            }
            return View(budgetLimit);
        }

        // POST: BudgetLimits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetLimit budgetLimit = db.BudgetLimits.Find(id);
            db.BudgetLimits.Remove(budgetLimit);
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
