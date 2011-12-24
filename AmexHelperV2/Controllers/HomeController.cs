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

           string[] viewBlob = System.Web.Security.Roles.GetRolesForUser();

           //string[] usersBlob = System.Web.Security.Roles.FindUsersInRole("BUILTIN\\Administrators","Administrator");
           ViewBag.BoolBlob = User.IsInRole("BUILTIN\\Administrators");
            
            ViewBag.Blob = viewBlob;



            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
