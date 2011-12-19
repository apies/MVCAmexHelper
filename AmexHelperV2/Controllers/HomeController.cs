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
    public class HomeController : Controller
    {
        private AmexHelperDB db = new AmexHelperDB();
        
        public ActionResult Index()
        {
            
            String uName = User.Identity.Name;

            int index = uName.IndexOf("\\",0);

            ViewBag.Message = User.Identity.Name.Substring(index + 1 ) ;




            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
