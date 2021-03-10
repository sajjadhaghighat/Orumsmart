using Ourmsmart.Filter;
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
            if (Session["Auth"] != null)
            {
                if ((string)Session["Auth"] == "Customer")
                {
                    return RedirectToAction("MyProfile", "Customer");
                }
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            Customer c = customer;
            if (c.Fullname == null || c.Phone==null || c.Email==null || c.Username==null || c.Password==null)
            {
                return Json(new { success = false, message = "موارد ضروری را پر کنید" });
            }
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "ناسازگاری پایگاه داده" });
            }
            try
            {
                var q = (from a in db.Customers select a).Where(x => x.Username == customer.Username).FirstOrDefault();
                if (q != null)
                {
                    return Json(new { success = false, message = "نام کاربری مجاز نمی باشد." });
                }
                db.Customers.Add(customer);
                db.SaveChanges();
                return Json(new { success = true, message = "ثبت نام با موفقیت انجام شد" });
                
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "خطایی رخ داد. مجددا در تایم بعدی سعی کنید." });
                throw;
            }
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