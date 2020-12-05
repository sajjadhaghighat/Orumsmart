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
        [HttpPost]
        [Route("api/Auth/login")]
        public IHttpActionResult login(Users user)
        {
            if (user.Username == "sajjad" && user.Password == "137596")
            {
                AuthFilter.Role = "Admin";
                return Json(new { success = true, message = "You Login Successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Your Information is Incorrect." });
            }
        }

        [HttpGet]
        [Route("api/Auth/logout")]
        public IHttpActionResult logout()
        {
            AuthFilter.Role = null;
            return Json(new { message = "You Logout Successfully.", title = "Exit" });
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
