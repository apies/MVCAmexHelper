using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmexHelperV2.Models;
using System.IO;
using CsvHelper;

namespace AmexHelperV2.Controllers
{ 
    public class ChargesController : Controller
    {
        private AmexHelperDB db = new AmexHelperDB();

        //
        // GET: /Charges/

        public ViewResult Index()
        {
            return View(db.Charges.ToList());
        }

        
        
        //CSV upload

        [HttpPost]
        public ViewResult Index(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var newPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", fileName);
            file.SaveAs(newPath);

            //var sr = new StreamReader("c:\\dump\\blobs.csv");
            var sr = new StreamReader(newPath);
            var csvReader = new CsvReader(sr);

            while (csvReader.Read())
            {
                if (csvReader.GetField("CARDMEMBER_NAME") != null && csvReader.GetField("CARDMEMBER_NAME") != "")
                {

                    Charge charge = new Charge();

                    //test upload fields
                    //charge.Cardholder = csvReader.GetField("Cardholder");
                    //charge.Amount = Convert.ToDecimal(csvReader.GetField("Amount"));
                    //charge.DateofPurchase = csvReader.GetField<DateTime>("Date Of Purchase");

                    //true upload fields and logic
                    Decimal rawAmount = csvReader.GetField<Decimal>("BILLING_AMOUNT");
                    int dbcr = csvReader.GetField<int>("DB\\CR_INDICATOR");
                    if (dbcr == 3)
                    { rawAmount = 0; }
                    else if (dbcr == 2)
                    { rawAmount = -rawAmount; }
                    else if (dbcr == 4)
                    { rawAmount = 0; }

                    charge.Amount = rawAmount;
                    charge.DateofPurchase = (csvReader.GetField<DateTime>("PROCESS_DATE"));
                    charge.Description = csvReader.GetField("CHARGE_DESCRIPTION_LINE1");
                    charge.ReferenceInfo = csvReader.GetField("CHARGE_DESCRIPTION_LINE2");
                    charge.AirTraveler = csvReader.GetField("AIR_PASSENGER_NAME");
                    charge.AirRoute = csvReader.GetField("AIR_ROUTING");
                    charge.Cardholder = csvReader.GetField("CARDMEMBER_NAME");





                    db.Charges.Add(charge);
                    db.SaveChanges();
                }



            }

            IEnumerable<IGrouping<String, Charge>> groupedcharges = from charge in db.Charges
                                group charge by charge.Cardholder;
             
 

            foreach (var report in groupedcharges.ToList())
            {

                Decimal totalAmount = (from charge in report
                                       select charge.Amount).Sum();
                ExpenseReport eReport = new ExpenseReport();
                eReport.Employee = report.Key;
                eReport.Month = "February";
                eReport.Date = DateTime.Now;
                var eCharges = from charge in report
                                  select charge;
                eReport.Charges = eCharges.ToList();
                eReport.TotalAmount = totalAmount;

                db.ExpenseReports.Add(eReport);
                db.SaveChanges();
            
            
            }

          

            sr.Close();

            System.IO.File.Delete(newPath);

            return View(db.Charges.ToList());
        }
        
        
        
        
        
        //
        // GET: /Charges/Details/5

        public ViewResult Details(int id)
        {
            Charge charge = db.Charges.Find(id);
            return View(charge);
        }

        //
        // GET: /Charges/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Charges/Create

        [HttpPost]
        public ActionResult Create(Charge charge)
        {
            if (ModelState.IsValid)
            {
                db.Charges.Add(charge);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(charge);
        }
        
        //
        // GET: /Charges/Edit/5
 
        public ActionResult Edit(int id)
        {
            Charge charge = db.Charges.Find(id);
            return View(charge);
        }

        //
        // POST: /Charges/Edit/5

        [HttpPost]
        public ActionResult Edit(Charge charge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charge);
        }

        //
        // GET: /Charges/Delete/5
 
        public ActionResult Delete(int id)
        {
            Charge charge = db.Charges.Find(id);
            return View(charge);
        }

        //
        // POST: /Charges/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Charge charge = db.Charges.Find(id);
            db.Charges.Remove(charge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}