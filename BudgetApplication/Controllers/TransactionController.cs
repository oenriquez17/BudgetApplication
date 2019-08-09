using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.DAL;
using System.Data.Entity;
using BudgetApplication.Models;

namespace BudgetApplication.Controllers
{
    public class TransactionController : Controller
    {
        DatabaseContext _context;

        public TransactionController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NewTransaction()
        {
            var accounts = getAccounts();

            //Given the list of accounts, the user will be able to selecte accounts
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
                            AccountName = a.AccountName,
                            AccountType = a.AccountType,
                            AccountTypeId = a.AccountTypeId,
                            Balance = a.Balance
                        };

            foreach (var acc in query)
            {
                accounts.Add(new Account
                {
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