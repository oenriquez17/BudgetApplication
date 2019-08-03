using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using BudgetApplication.DAL;
using System.Data.Entity.Validation;

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
            foreach (var type in accountTypes)
            {
                System.Diagnostics.Debug.WriteLine(type.AccountTypeId);
                System.Diagnostics.Debug.WriteLine(type.AccountTypeName);
            }
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
            System.Diagnostics.Debug.WriteLine(account.AccountTypeId);

            _context.Account.Add(account);
            _context.SaveChanges();

            return RedirectToAction("Index", "Accounts");
        }
    }
}