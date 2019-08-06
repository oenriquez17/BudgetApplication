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

            if (filterContext.HttpContext.Session["userId"] == null)
            {
                // check if a new session id was generated
                filterContext.Result = new RedirectResult("~/User/Index");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}