using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AmexHelperV2.Models;

namespace AmexHelperV2.Controllers
{ 
    public class ExpenseReportsController : Controller
    {
        private AmexHelperDB db = new AmexHelperDB();

        //
        // GET: /ExpenseReports/

        public ViewResult Index()
        {
            return View(db.ExpenseReports.ToList());
        }

        //
        // GET: /ExpenseReports/Details/5

        public ViewResult Details(int id)
        {
            ExpenseReport expensereport = db.ExpenseReports.Find(id);
            ViewBag.Charges = expensereport.Charges.ToList();

            return View(expensereport);
        }

        //
        // GET: /ExpenseReports/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ExpenseReports/Create

        [HttpPost]
        public ActionResult Create(ExpenseReport expensereport)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseReports.Add(expensereport);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(expensereport);
        }
        
        //
        // GET: /ExpenseReports/Edit/5
 
        public ActionResult Edit(int id)
        {
            ExpenseReport expensereport = db.ExpenseReports.Find(id);
            return View(expensereport);
        }

        //
        // POST: /ExpenseReports/Edit/5

        [HttpPost]
        public ActionResult Edit(ExpenseReport expensereport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expensereport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expensereport);
        }

        //
        // GET: /ExpenseReports/Delete/5
 
        public ActionResult Delete(int id)
        {
            ExpenseReport expensereport = db.ExpenseReports.Find(id);
            return View(expensereport);
        }

        //
        // POST: /ExpenseReports/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ExpenseReport expensereport = db.ExpenseReports.Find(id);
            db.ExpenseReports.Remove(expensereport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        public ActionResult MyReport()
        {

            String uName = User.Identity.Name;

            int index = uName.IndexOf("\\", 0);

            ViewBag.Message = User.Identity.Name.Substring(index + 1);




            ExpenseReport expensereport = db.ExpenseReports.Where(c => c.Employee == User.Identity.Name.Substring(index + 1)).FirstOrDefault();

            ViewBag.Charges = expensereport.Charges.ToList();
            return View(expensereport);


        }







    }
}