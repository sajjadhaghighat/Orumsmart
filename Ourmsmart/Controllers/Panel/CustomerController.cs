using Ourmsmart.Filter;
using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers.Panel
{
    [CusFilter]
    public class CustomerController : Controller
    {
        VIRADB db = new VIRADB();
        // GET: Customer
        public ActionResult MyProfile()
        {
            string auth = (string)Session["Username"];
            var q = (from a in db.Customers where a.Username == auth select a).FirstOrDefault();
            return View(q);
        }
    }
}