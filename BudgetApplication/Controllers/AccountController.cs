using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using BudgetApplication.DAL;
using System.Data.Entity.Validation;

namespace BudgetApplication.Controllers
{
    public class AccountController : Controller
    {
        //DB Context object. Initialized by class constructor
        DatabaseContext _context;

        public AccountController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = _context.Account.Include(a => a.AccountType).ToList();
            return View(accounts);
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
        public ActionResult SaveAccount(Account account) 
        {

            _context.Account.Add(account);
            _context.SaveChanges();

            var accountId = account.AccountId;
            var userId = (int) Session["userId"];
            var accountUser = new AccountUser
            {
                AccountId = accountId,
                UserId = userId
            };

            _context.AccountUser.Add(accountUser);
            _context.SaveChanges();
                
            return RedirectToAction("Index", "Account");
        }
    }
}