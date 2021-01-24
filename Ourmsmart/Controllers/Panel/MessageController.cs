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
    }
}