using Ourmsmart.Filter;
using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers
{
    [BothFilter]
    public class ProfileController : Controller
    {
        VIRADB db = new VIRADB();
        // Show: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UID,Fullname,Username,Password,Email,Bio,Team,Type,Imagepath")] FAUser fAUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAUser);
        }

    }
}