using Ourmsmart.Filter;
using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ourmsmart.Controllers
{
    
    public class AuthController : Controller
    {
        public class Users
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        VIRADB db = new VIRADB();

        [HttpPost]
        public ActionResult login(Users u)
        {
            var q = (from a in db.FAUsers select a).Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();
            if (q != null)
            {
                Session["Auth"] = q.Type;
                Session["Username"] = q.Username;
                Session.Timeout = 60;
                return Json(new { success = true, message = "با موفقیت وارد شدید", title = "سلام" });
            }
            else
            {
                return Json(new { success = false, message = "اطلاعات ورودی صحیح نیست", title = "خطا" });
            }
        }

        [HttpPost]
        public ActionResult logout()
        {
            Session["Auth"] = null;
            Session["Username"] = null;
            return Json(new { message = "با موفقیت خارج شدید", title = "خروج از حساب" });
        }

        
    }
}
