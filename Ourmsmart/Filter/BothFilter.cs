using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ourmsmart.Filter
{
    public class BothFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            try
            {
                if (actionContext.HttpContext.Session["Auth"].ToString() == "Employee" || actionContext.HttpContext.Session["Auth"].ToString() == "Admin")
                {
                    base.OnActionExecuting(actionContext);
                }
                else
                {
                    //actionContext.Result = new System.Web.Mvc.HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                    actionContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Message", action = "http401" }));
                    actionContext.Result.ExecuteResult(actionContext.Controller.ControllerContext);
                    return;
                }
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