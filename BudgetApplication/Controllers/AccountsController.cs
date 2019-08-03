using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using BudgetApplication.DAL;

namespace BudgetApplication.Controllers
{
    public class AccountsController : Controller
    {
        //DB Context object. Initialized by class constructor
        DatabaseContext _context;

        public AccountsController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }

        // Shows the new/update account form
        public ActionResult AccountForm()
        {
            var accountTypes = _context.AccountType.ToList();
            var accountViewModel = new NewAccountViewModel
            {
                Account = new Account(),
                AccountTypes = accountTypes
            };
            return View(accountViewModel);
        }

        // POST: This action will add an account and redirect to Index
        [HttpPost]
        public ActionResult SaveAccount(Account newAccount) 
        {
            _context.Account.Add(newAccount);

            return RedirectToAction("Index", "Accounts");
        }
    }
}