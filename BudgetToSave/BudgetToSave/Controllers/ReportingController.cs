using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetToSave.Models;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;

namespace BudgetToSave.Controllers
{
    public class ReportingController : Controller
    {
        BudgetDBEntities db = new BudgetDBEntities();
        // GET: EXport
        public ActionResult MonthlySpendingList()
        {
            return View(db.MonthlySpendings.ToList());
        }
        public ActionResult Reports(string ReportType)
        {
            LocalReport localreport = new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Report/Report1.rdlc");

            ReportDataSource reportdatasource = new ReportDataSource();
            reportdatasource.Name = "MonthlySpending";
            reportdatasource.Value = db.MonthlySpendings.ToList();
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
            Response.AddHeader("content-disposition", "MonthlyReport");


            return File(renderedByte, FileNameExtension);

        }

    }
}