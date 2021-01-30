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

        [HttpPost]
        public void Updatepropic(HttpPostedFileBase imagefile)
        {
            string filename = Path.GetFileNameWithoutExtension(imagefile.FileName);
            string extension = Path.GetExtension(imagefile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = "~/Content/images/admin/" + filename;
            filename = Path.Combine(Server.MapPath("~/Content/images/admin/"), filename);
            imagefile.SaveAs(filename);
            //string imgpath = "<img src='" + path + "' />";
            //return Content(imgpath , "text/html");
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