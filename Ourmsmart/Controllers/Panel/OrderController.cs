using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ourmsmart.Filter;
using Ourmsmart.Models;

namespace Ourmsmart.Controllers.Panel
{
    [BothFilter]
    public class OrderController : Controller
    {
        VIRADB db = new VIRADB();
        // GET: Order
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
                return RedirectToAction("failOrder", "Message");
            }

        }

        [HttpPost]
        public ActionResult traceOrder(string trace)
        {
            var q = from a in db.Orders where a.Tracingcode == trace select a;
            return View(q);
        }

        public ActionResult detailOrder(string trace)
        {
            var q = from a in db.Orders where a.Tracingcode == trace select a;
            return View(q);
        }


    }
}