using Ourmsmart.Filter;
using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpPost]
        public ActionResult UpdateProfile(Customer customer)
        {
            Customer c = customer;
            if (c.Fullname == null || c.Phone == null || c.Email == null || c.Username == null || c.Password == null)
            {
                return Json(new { success = false, message = "موارد ضروری را پر کنید" });
            }
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "ناسازگاری پایگاه داده" });
            }
            try
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "ویرایش با موفقیت انجام شد" });

            }
            catch (Exception)
            {
                return Json(new { success = false, message = "خطایی رخ داد. مجددا در تایم بعدی سعی کنید." });
                throw;
            }
        }

        public ActionResult MyOrders()
        {
            string auth = (string)Session["Username"];
            Customer cus = (from a in db.Customers where a.Username == auth select a).FirstOrDefault();
            var q = (from c in db.Orders
                     group c by c.Cartid into uniqueIds
                     select uniqueIds.FirstOrDefault()).OrderByDescending(x => x.OID).Where(x=>x.UserId == cus.CusID);
            return View(q);
        }
    }
}