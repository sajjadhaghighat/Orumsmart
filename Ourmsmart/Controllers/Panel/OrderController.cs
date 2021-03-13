using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ourmsmart.Filter;
using Ourmsmart.Models;

namespace Ourmsmart.Controllers.Panel
{
    
    public class OrderController : Controller
    {
        VIRADB db = new VIRADB();
        // GET: Order
        [BothFilter]
        public ActionResult Index()
        {
            var q = (from c in db.Orders
                                 group c by c.Cartid into uniqueIds
                                 select uniqueIds.FirstOrDefault()).OrderByDescending(x => x.OID);
            return View(q);
        }

        [HttpPost] 
        public ActionResult insertOrder(Order order, OrderAddress oaddress)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("failOrder", "Message");
            }
            try
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random rd = new Random();
                int rand_num = rd.Next(1, 1000000000);
                List<Cbasket> cb = (List<Cbasket>)Session["Basket"];
                string trace =  new string(Enumerable.Repeat(chars, 24).Select(s => s[rd.Next(s.Length)]).ToArray());
                foreach (var item in cb)
                {
                    order.Cartid = rand_num;
                    order.Timestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss tt");
                    order.Oqty = item.Qty;
                    order.PID = item.PID;
                    order.Status = "در انتظار بررسی";
                    order.Price = (item.Qty * Int32.Parse(db.FAProducts.Find(item.PID).Price)).ToString();
                    order.Tracingcode = trace;
                    string auth = (string)Session["Username"];
                    Customer cus = (from a in db.Customers where a.Username == auth select a).FirstOrDefault();
                    order.UserId = cus.CusID;
                    if (order.Paycode == null) { order.Paycode = "Off"; } 
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                oaddress.Cartid = rand_num;
                db.OrderAddresses.Add(oaddress);
                db.SaveChanges();
                return RedirectToAction("commitOrder", "Message", new { trace = trace});
            }
            catch (Exception)
            {
                return RedirectToAction("AbortOrder", "Message");
            }

        }

        [HttpPost]
        public ActionResult traceOrder(string trace)
        {
            try
            {
                var q = (from a in db.Orders where a.Tracingcode == trace select a);
                if (q != null)
                {
                    return View(q);
                }
                else
                {
                    return RedirectToAction("AbortOrder", "Message");
                }
                
            }
            catch (Exception)
            {
                return RedirectToAction("AbortOrder", "Message");
            }
            
        }

        [AUCFilter]
        public ActionResult detailOrder(string trace)
        {
            var q = from a in db.Orders where a.Tracingcode == trace select a;
            return View(q);
        }

        [BothFilter]
        public ActionResult showeditOrder(int id)
        {
            Order o = db.Orders.Find(id);
            return View(o);
        }

        [BothFilter]
        [HttpPost]
        public ActionResult editOrder(Order o)
        {
            var q = (from a in db.Orders select a).Where(x => x.Cartid == o.Cartid);
            try
            {
                foreach (var item in q)
                {
                    if (ModelState.IsValid)
                    {
                        item.Status = o.Status;
                        o = item;
                        db.Entry(o).State = EntityState.Modified;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult deleteOrder(int cartId)
        {
            var q = (from a in db.Orders select a).Where(x => x.Cartid == cartId);
            OrderAddress ad = (from a in db.OrderAddresses select a).Where(x => x.Cartid == cartId).FirstOrDefault();
            try
            {
                foreach (var item in q)
                {
                    if (ModelState.IsValid)
                    {
                        db.Orders.Remove(item);
                    }
                }
                db.OrderAddresses.Remove(ad);
                db.SaveChanges();
                return Json(new { success = true, message = "سفارش حذف شد" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "مشکلی در عملیات بوجود آمد" });
            }
        }


    }
}