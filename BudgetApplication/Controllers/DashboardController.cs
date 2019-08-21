using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.Models;
using System.Data.Entity;
using BudgetApplication.DAL;
using BudgetApplication.SessionAuth;

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

            foreach (var acc in query)
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
    }
}