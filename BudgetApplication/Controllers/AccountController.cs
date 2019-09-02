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
using BudgetApplication.SessionAuth;

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
        [CheckSession]
        public ActionResult Index()
        {
            var accounts = getAccounts();
            
            return View(accounts);
        }

        // Method to generate list of accounts based on user Id
        private List<Account> getAccounts()
        {
            List<Account> accounts = new List<Account>();

            var userId = (int)Session["userId"];
            var query = from a in _context.Account.Include(a => a.AccountType)
                        join au in _context.AccountUser
                        on a.AccountId equals au.AccountId
                        where au.UserId == userId
                        select new 
                        {
                            a.AccountId,
                            a.AccountName,
                            a.AccountType,
                            a.AccountTypeId,
                            a.Balance
                        };

            foreach(var acc in query)
            {
                accounts.Add(new Account
                {
                    AccountId = acc.AccountId,
                    AccountName = acc.AccountName,
                    AccountType = acc.AccountType,
                    AccountTypeId = acc.AccountTypeId,
                    Balance = acc.Balance
                });
            }

            return accounts;
        }

        // Shows the new account form
        [CheckSession]
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
            if (!ModelState.IsValid)
            {
                var accountViewModel = new NewAccountViewModel
                {
                    Account = account,
                    AccountTypes = _context.AccountType.ToList()
                };
                return View(accountViewModel);
            }

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