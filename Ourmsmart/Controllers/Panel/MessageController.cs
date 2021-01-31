using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers.Panel
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult commitOrder(string trace)
        {
            ViewBag.trace = trace;
            return View();
        }
        public ActionResult AbortOrder()
        {
            return View();
        }
        public ActionResult http401()
        {
            return View();
        }

        public ActionResult DBerror()
        {
            return View();
        }

        public ActionResult SuccessInsertProduct()
        {
            return View();
        }
    }

}