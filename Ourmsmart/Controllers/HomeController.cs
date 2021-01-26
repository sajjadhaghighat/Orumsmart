using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers
{
    public class HomeController : Controller
    {
        VIRADB db = new VIRADB();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if(!ModelState.IsValid)
            {
                return Json(new { success = false, message = "پیام شما ارسال نشد. مجددا در تایم بعدی سعی کنید." });
            }
            try
            {
                contact.Timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss tt");
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Json(new { success = true, message = "پیام شما با موفقیت ارسال شد" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "پیام شما ارسال نشد. مجددا در تایم بعدی سعی کنید." });
            }


        }

    }
}