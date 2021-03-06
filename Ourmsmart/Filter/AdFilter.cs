using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ourmsmart.Filter
{

    public class AdFilter : ActionFilterAttribute
    {
        
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            try
            {
                if (actionContext.HttpContext.Session["Auth"].ToString() != "Admin")
                {
                    //actionContext.Result = new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    actionContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Message", action = "http401" }));
                    actionContext.Result.ExecuteResult(actionContext.Controller.ControllerContext);
                    return;
                }
                else
                    base.OnActionExecuting(actionContext);
            }
            catch (Exception)
            {
                actionContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Message", action = "http401" }));
                actionContext.Result.ExecuteResult(actionContext.Controller.ControllerContext);
                return;
            }
        }
    }
}