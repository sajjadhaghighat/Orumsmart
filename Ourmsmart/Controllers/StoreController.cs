using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Ourmsmart.Controllers
{
    public class Cbasket
    {
        public int PID { get; set; }
        public int Qty { get; set; }
        
        public Cbasket(int pid,int qty)
        {
            PID = pid; Qty = qty;
        }
    }
    
    public class StoreController : Controller
    {
        private VIRADB db = new VIRADB();
        List<Cbasket> cb = new List<Cbasket>();
        // GET: Store
        public ActionResult Index(string Category, string search,int? page)
        {
            if (Category != null)
            {
                var q = db.FAProducts.Where( x => x.FACategory.family == search || search == null).ToList().ToPagedList(page ?? 1, 1);
                return View(q);
            }
            else
            {
                var q = db.FAProducts.Where(x => x.Title.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 1);
                return View(q);
            }
          
            
        }

        public ActionResult Products()
        {
            var q = from a in db.FAProducts select a;
            return View(q);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateProduct(FAProduct product)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { message = "" , title = ""});
            }
            try
            {
                db.FAProducts.Add(product);
                db.SaveChanges();
                return Json(new { message = "", title = "" });
            }
            catch (Exception)
            {
                return Json(new { message = "", title = "" });
            }
        }

        public ActionResult Detail(int id)
        {
            var q = db.FAProducts.Where(x => x.PID == id).FirstOrDefault();
            return View(q);
        }

        
        public ActionResult AddItemToBasket(int pid, int qty)
        {
            if (Session["Basket"] != null)
            {
                cb = (List<Cbasket>)Session["Basket"];
                var index = cb.FindIndex(a => a.PID == pid);
                if (index > -1)
                {
                    cb[index].Qty = cb[index].Qty + qty;
                    Session["Basket"] = cb;
                    return RedirectToAction("Index");
                }
            }
            cb.Add(new Cbasket(pid, qty));
            Session["Basket"] = cb;
            return RedirectToAction("Index");
        }

        public ActionResult DelItemFromBascket(int id)
        {
            cb = (List<Cbasket>)Session["Basket"];
            var index = cb.FindIndex(a => a.PID == id);
            cb.RemoveAt(index);
            if (cb.Count>0)
            {
                Session["Basket"] = cb;
            }
            else
            {
                Session["Basket"] = null;
            }
            return RedirectToAction("Index");
        }
    }


}