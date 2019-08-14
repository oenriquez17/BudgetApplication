using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BudgetApplication.SessionAuth
{
    public class CheckSession : ActionFilterAttribute
    {

        //This method checks if a session exists. If it doesn't, it redirects the user to the Login Page
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //If no session is found, save source page and redirect user after login
            if (filterContext.HttpContext.Session["userId"] == null)
            {
                var sourcePath = filterContext.HttpContext.Request.Path;
                string[] url = sourcePath.TrimStart('/').Split('/');
                if (url.Length == 2)
                {
                    filterContext.HttpContext.Session["targetController"] = url[0];
                    filterContext.HttpContext.Session["targetAction"] = url[1];
                }

                filterContext.Result = new RedirectResult("~/User/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}