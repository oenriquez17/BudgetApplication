using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.DAL;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;

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
            if (Session["userId"] == null)
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
                //Set session variable
                Session["userId"] = usersFound.UserId;

                //Check if user was trying to access a specific page
                if (Session["targetController"] != null && Session["targetAction"] != null)
                {
                    //Get controller and action
                    string controller = (string) Session["targetController"];
                    string action = (string) Session["targetAction"];

                    //Destroy variables from session
                    Session.Remove("targetController");
                    Session.Remove("targetAction");

                    return RedirectToAction(action, controller);
                } else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            } else {
                ViewData["ErrorMessage"] = "Username or Password are invalid";
                return View("Index");
            }
        }

        public ActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult ProcessRegister(RegisterViewModel model)
        {
            var newUser = _context.User.Add(new User
            {
                Username = model.Username,
                Password = model.Password
            });

            Session["userId"] = newUser.UserId;

            return RedirectToAction("Index", "Account");
        }

        public ActionResult Logout()
        {
            Session["userId"] = null;
            return View("Index");
        }
    }
}