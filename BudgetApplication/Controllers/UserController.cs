using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.DAL;
using BudgetApplication.Models;

namespace BudgetApplication.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext _context;

        public UserController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Index view = Login page
        public ActionResult Index()
        {
            if(Session["userId"] == null)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "Account");
            }
        }

        //Method that attempts to login
        [HttpPost]
        public ActionResult Login(User user)
        {
            var usersFound = _context.User
                .Where(u => u.Username == user.Username && u.Password == user.Password)
                .FirstOrDefault();

            if(usersFound != null) {
                Session["userId"] = usersFound.UserId;
                return RedirectToAction("Index", "Account");
            } else {
                ViewData["ErrorMessage"] = "Username or Password are invalid";
                return View("Index");
            }
        }
    }
}