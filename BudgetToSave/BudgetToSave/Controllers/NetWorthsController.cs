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
    public class NetWorthsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: NetWorths
        public ActionResult NetWorth()
        {
            return View(db.NetWorths.ToList());
        }

        // GET: NetWorths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetWorth netWorth = db.NetWorths.Find(id);
            if (netWorth == null)
            {
                return HttpNotFound();
            }
            return View(netWorth);
        }

        // GET: NetWorths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NetWorths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NetWorthID,Date,Amount")] NetWorth netWorth)
        {
            if (ModelState.IsValid)
            {
                db.NetWorths.Add(netWorth);
                db.SaveChanges();
                return RedirectToAction("NetWorth");
            }

            return View(netWorth);
        }

        // GET: NetWorths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetWorth netWorth = db.NetWorths.Find(id);
            if (netWorth == null)
            {
                return HttpNotFound();
            }
            return View(netWorth);
        }

        // POST: NetWorths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NetWorthID,Date,Amount")] NetWorth netWorth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(netWorth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("NetWorth");
            }
            return View(netWorth);
        }

        // GET: NetWorths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NetWorth netWorth = db.NetWorths.Find(id);
            if (netWorth == null)
            {
                return HttpNotFound();
            }
            return View(netWorth);
        }

        // POST: NetWorths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NetWorth netWorth = db.NetWorths.Find(id);
            db.NetWorths.Remove(netWorth);
            db.SaveChanges();
            return RedirectToAction("NetWorth");
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
