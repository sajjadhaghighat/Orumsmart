using Ourmsmart.Filter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers
{
    //[ActFilter]
    public class PanelController : Controller
    {
        // GET: Panel
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


    }
}