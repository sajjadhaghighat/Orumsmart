using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ourmsmart.Models;

namespace Ourmsmart.Controllers.Panel
{
    public class OrderController : Controller
    {
        VIRADB db = new VIRADB();
        // GET: Order
        public ActionResult Index()
        {
            return View();
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
                    order.Timestamp = DateTime.Now.ToString("h:mm:ss tt");
                    order.Oqty = item.Qty;
                    order.PID = item.PID;
                    order.Status = "در انتظار بررسی";
                    order.Price = (item.Qty * db.FAProducts.Find(item.PID).Price).ToString();
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

    }
}