using Ourmsmart.Filter;
using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace Ourmsmart.Controllers
{
    
    public class AuthController : ApiController
    {
        public class Users
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        VIRADB db = new VIRADB();

        [HttpPost]
        [Route("api/Auth/login")]
        public IHttpActionResult login(Users u)
        {
            var q = (from a in db.FAUsers select a).Where(x => x.Username == u.Username && x.Password == u.Password).FirstOrDefault();
            if (q != null)
            {
                AuthFilter.Role = q.Type;
                AuthFilter.username = q.Username;
                return Json(new { success = true, message = "با موفقیت وارد شدید", title = "سلام" });
            }
            else
            {
                return Json(new { success = false, message = "اطلاعات ورودی صحیح نیست", title = "خطا" });
            }
        }

        [HttpGet]
        [Route("api/Auth/logout")]
        public IHttpActionResult logout()
        {
            AuthFilter.Role = null;
            return Json(new { message = "با موفقیت خارج شدید", title = "خروج از حساب" });
        }

        /*[HttpPost]
        public HttpResponseMessage Updatepropic(HttpPostedFileBase file)
        {
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            string path = "~/Content/images/admin/" + filename;
            filename = Path.Combine(HostingEnvironment.MapPath("~/Content/images/admin/"), filename);
            file.SaveAs(filename);
            string imgpath = "<img src='" + filename + "' />";
            var response = new HttpResponseMessage();
            response.Content = new StringContent(imgpath);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }*/
    }
}
