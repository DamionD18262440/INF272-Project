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
    public class MonthlySpendingsController : Controller
    {
        private BudgetDBEntities db = new BudgetDBEntities();

        // GET: MonthlySpendings
        public ActionResult Index()
        {
            return View(db.MonthlySpendings.ToList());
        }
        public ActionResult Home()
        {
            return View();
        }

        // GET: MonthlySpendings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySpending monthlySpending = db.MonthlySpendings.Find(id);
            if (monthlySpending == null)
            {
                return HttpNotFound();
            }
            return View(monthlySpending);
        }

        // GET: MonthlySpendings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlySpendings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonthlySpendingID,FoodAmount,ClothesAmount,AlcoholAmount,OtherAmount,Date")] MonthlySpending monthlySpending)
        {
            if (ModelState.IsValid)
            {
                db.MonthlySpendings.Add(monthlySpending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monthlySpending);
        }

        // GET: MonthlySpendings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySpending monthlySpending = db.MonthlySpendings.Find(id);
            if (monthlySpending == null)
            {
                return HttpNotFound();
            }
            return View(monthlySpending);
        }

        // POST: MonthlySpendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonthlySpendingID,FoodAmount,ClothesAmount,AlcoholAmount,OtherAmount,Date")] MonthlySpending monthlySpending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monthlySpending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monthlySpending);
        }

        // GET: MonthlySpendings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonthlySpending monthlySpending = db.MonthlySpendings.Find(id);
            if (monthlySpending == null)
            {
                return HttpNotFound();
            }
            return View(monthlySpending);
        }

        // POST: MonthlySpendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonthlySpending monthlySpending = db.MonthlySpendings.Find(id);
            db.MonthlySpendings.Remove(monthlySpending);
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
       // public ActionResult DownloadFile() //Normal controller method signature – ActionResult return type
       // {
            //var fileDownloadName = “download.xlsx"; //provide appropriate file name
            //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; //set content type (MIME type)
            //IO.FileStream fs = new IO.FileStream(filePath, IO.FileMode.Open, IO.FileAccess.Read); //load file into File Stream
           // IO.MemoryStream ms = new IO.MemoryStream(); //Instantiate new MemoryStream
            //fs.CopyTo(ms); //Copy FileStream into MemoryStream
           // var fsr = new FileStreamResult(ms, contentType); //Create new FileStreamResult from MemoryStream
           // fsr.FileDownloadName = fileDownloadName; //Set FileResult’s name
           // return fsr; //Return FileStreamResult object
        //}
    }
}
