using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.Models;
using System.Data.Entity;
using BudgetApplication.DAL;

namespace BudgetApplication.Controllers
{
    public class DashboardController : Controller
    {
        DatabaseContext _context;

        public DashboardController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Dashboard
        public ActionResult Index()
        {
            if(Session["userId"] == null)
            {
                return RedirectToAction("Index", "User");
            } else
            {
                var userId = Session["userId"];
                var accounts = _context.Account.Include(a => a.AccountType);
                return View();
            }
        }
    }
}