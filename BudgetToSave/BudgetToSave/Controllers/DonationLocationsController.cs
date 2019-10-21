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
    public class DonationLocationsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: DonationLocations
        public ActionResult Index()
        {
            var donationLocations = db.DonationLocations.Include(d => d.Donation).Include(d => d.Location);
            return View(donationLocations.ToList());
        }

        // GET: DonationLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationLocation donationLocation = db.DonationLocations.Find(id);
            if (donationLocation == null)
            {
                return HttpNotFound();
            }
            return View(donationLocation);
        }

        // GET: DonationLocations/Create
        public ActionResult Create()
        {
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID");
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description");
            return View();
        }

        // POST: DonationLocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationLocation1,LocationID,DonationID")] DonationLocation donationLocation)
        {
            if (ModelState.IsValid)
            {
                db.DonationLocations.Add(donationLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", donationLocation.DonationID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donationLocation.LocationID);
            return View(donationLocation);
        }

        // GET: DonationLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationLocation donationLocation = db.DonationLocations.Find(id);
            if (donationLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", donationLocation.DonationID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donationLocation.LocationID);
            return View(donationLocation);
        }

        // POST: DonationLocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationLocation1,LocationID,DonationID")] DonationLocation donationLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donationLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonationID = new SelectList(db.Donations, "DonationID", "DonationID", donationLocation.DonationID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donationLocation.LocationID);
            return View(donationLocation);
        }

        // GET: DonationLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonationLocation donationLocation = db.DonationLocations.Find(id);
            if (donationLocation == null)
            {
                return HttpNotFound();
            }
            return View(donationLocation);
        }

        // POST: DonationLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonationLocation donationLocation = db.DonationLocations.Find(id);
            db.DonationLocations.Remove(donationLocation);
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
