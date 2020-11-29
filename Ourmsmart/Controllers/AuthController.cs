using Ourmsmart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                return Json(new { success = true, message = "You Login Successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Your Information is Incorrect." });
            }
        }
    }
}
