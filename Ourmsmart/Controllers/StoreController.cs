using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers
{
    
    public class StoreController : Controller
    {
        private VIRADB db = new VIRADB();
        // GET: Store
        public ActionResult Index(string searchBy,string search,int? page)
        {
            var q = from a in db.FAProducts select a;
            return View(q);
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
    }
}