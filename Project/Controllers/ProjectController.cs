using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ProjectController : Controller
    {
        INF272ProjectEntities1 BudgetDB = new INF272ProjectEntities1();
        // GET: Project
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult BudgetLimits()
        {
            return View();
        }
        public ActionResult SpendingTransaction()
        {
            return View();
        }
        public ActionResult IncomeTransaction()
        {
            return View();
        }
        public ActionResult InvestmentCalculator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InvestmentCalculator(double amount, double interestrate, int interesttype, int interestperiod, int investmenttype, double numofyears)
        {
            double Mamount = amount;
            double Minterestrate = interestrate;
            int Minteresttype = interesttype;
            int Minterestperiod = interestperiod;
            int Minvestmenttype = investmenttype;
            double Mnumofyears = numofyears;

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
        public ActionResult MonthlySpending()
        {

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ReportNetworth()
        {
            return View();
        }
        public ActionResult ReportSavings()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult UpdateUser()
        {
            return View();
        }
        public ActionResult InvestmentMade()
        {
            return View();
        }
    }
}