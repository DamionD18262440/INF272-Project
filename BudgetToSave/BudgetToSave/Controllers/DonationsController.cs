using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetToSave.Models;
using Microsoft.Reporting.WebForms;

namespace BudgetToSave.Controllers
{
    public class DonationsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: Donations
        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.DonationType).Include(d => d.Location);
            return View(donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.DonationTypeID = new SelectList(db.DonationTypes, "DonationTypeID", "Description");
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,Date,Amount,LocationID,DonationTypeID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Donations.Add(donation);
                    db.SaveChanges();
                }
               catch(Exception err)
                {
                    ViewBag.mefd = "Error" + err;
                    return View();
                }
                return RedirectToAction("Index");
            }

            ViewBag.DonationTypeID = new SelectList(db.DonationTypes, "DonationTypeID", "Description", donation.DonationTypeID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donation.LocationID);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonationTypeID = new SelectList(db.DonationTypes, "DonationTypeID", "Description", donation.DonationTypeID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donation.LocationID);
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,Date,Amount,LocationID,DonationTypeID")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonationTypeID = new SelectList(db.DonationTypes, "DonationTypeID", "Description", donation.DonationTypeID);
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Description", donation.LocationID);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
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
        public ActionResult Donations()
        {
            return View(db.Donations.ToList());
        }
        public ActionResult Reports2(string ReportType)
        {
            LocalReport localreport = new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Report/Report2.rdlc");

            ReportDataSource reportdatasource = new ReportDataSource();
            reportdatasource.Name = "Donations";
            reportdatasource.Value = db.Donations.ToList();
            localreport.DataSources.Add(reportdatasource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string FileNameExtension;
            if (ReportType == "PDF")
            {
                FileNameExtension = "pdf";
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = localreport.Render(ReportType, "", out mimeType, out encoding, out FileNameExtension, out streams, out warnings);
            // Response.AddHeader("content-disposition", "attachment:filename= MonthlyReport");
            Response.AddHeader("content-disposition", "DonationReport");


            return File(renderedByte, FileNameExtension);

        }
    }
}
