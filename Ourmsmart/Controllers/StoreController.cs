using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using Ourmsmart.Filter;

namespace Ourmsmart.Controllers
{
    public class Cbasket
    {
        public int PID { get; set; }
        public int Qty { get; set; }
        public List<int> Feature { get; set; }

        public Cbasket(int pid, int qty, List<int> cate)
        {
            PID = pid; Qty = qty;
            Feature = cate;
        }
    }

    public class StoreController : Controller
    {
        private VIRADB db = new VIRADB();
        List<Cbasket> cb = new List<Cbasket>();
        // GET: Store
        public ActionResult Index(string Category, string search, int? page)
        {
            if (Category != null)
            {
                var q = db.FAProducts.Where(x => x.Ptype == search || search == null).ToList().ToPagedList(page ?? 1, 4);
                return View(q);
            }
            else
            {
                var q = db.FAProducts.Where(x => x.Title.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 4);
                return View(q);
            }


        }

        [BothFilter]
        public ActionResult Products()
        {
            var q = (from a in db.FAProducts select a).OrderByDescending(x => x.PID);
            return View(q);
        }

        [BothFilter]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [BothFilter]
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateProduct(FAProduct product)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("DBerror", "Message");
            }
            try
            {
                db.FAProducts.Add(product);
                db.SaveChanges();
                return RedirectToAction("SuccessInsertProduct", "Message");
            }
            catch (Exception)
            {
                return RedirectToAction("DBerror", "Message");
            }
        }

        public ActionResult Detail(int id)
        {
            var q = db.FAProducts.Where(x => x.PID == id).FirstOrDefault();
            return View(q);
        }



        public ActionResult AddItemToBasket(int pid, int qty, List<int> Cate)
        {
            if (qty > 0)
            {
                if (Session["Basket"] != null)
                {
                    cb = (List<Cbasket>)Session["Basket"];
                    var index = cb.FindIndex(a => a.PID == pid && Cate.All(a.Feature.Contains) && a.Feature.Count == Cate.Count);
                    if (index > -1)
                    {
                        cb[index].Qty = cb[index].Qty + qty;
                        Session["Basket"] = cb;
                        return RedirectToAction("Index");
                    }
                }
                cb.Add(new Cbasket(pid, qty, Cate));
                Session["Basket"] = cb;
            }
            return RedirectToAction("Index");
        }

        public ActionResult DelItemFromBascket(int deid, int deqty, int decate , int count)
        {
            cb = (List<Cbasket>)Session["Basket"];
            var index = cb.FindIndex(a => a.PID == deid && a.Feature.Sum() == decate && a.Feature.Count == count);
            cb.RemoveAt(index);
            if (cb.Count > 0)
            {
                Session["Basket"] = cb;
            }
            else
            {
                Session["Basket"] = null;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [BothFilter]
        public ActionResult deleteProduct(int id)
        {
            try
            {
                FAProduct fa = db.FAProducts.Find(id);
                db.FAProducts.Remove(fa);
                db.SaveChanges();
                //return RedirectToAction("Products");
                return Json(new { success = true, message = "آیتم با موفقیت حذف شد" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "آیتم نمی تواند حذف شود. احتمالا آیتم در لیست سفارشات وجود دارد" });
                throw;
            }

        }

        [BothFilter]
        public ActionResult showeditProduct(int id)
        {
            FAProduct fa = db.FAProducts.Find(id);
            return View(fa);
        }

        [BothFilter]
        [HttpPost, ValidateInput(false)]
        public ActionResult editProduct(FAProduct fa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fa).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Products");
        }
    }


}