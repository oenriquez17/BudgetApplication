using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.DAL;
using System.Data.Entity;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using BudgetApplication.SessionAuth;

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

        [CheckSession]
        public ActionResult TransactionForm()
        {
            var accounts = getAccounts();
            var debitTransactionTypes = getDebitTransactionTypes();
            var creditTransactionTypes = getCreditTransactionTypes();

            var transactionFormViewModel = new NewTransactionViewModel
            {
                Accounts = accounts,
                DebitTransactionTypes = debitTransactionTypes,
                CreditTransactionTypes = creditTransactionTypes
            };

            //Given the list of accounts, the user will be able to selecte accounts
            return View(transactionFormViewModel);
        }

        [HttpPost]
        public ActionResult ProcessTransaction(NewTransactionViewModel model)
        {
            return Content(model.SelectedPrimaryAccountId.ToString());
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
                            AccountId = a.AccountId,
                            AccountName = a.AccountName,
                            AccountType = a.AccountType,
                            AccountTypeId = a.AccountTypeId,
                            Balance = a.Balance
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

        private IEnumerable<TransactionType> getCreditTransactionTypes()
        {
            var creditTransactionTypes = _context.TransactionType
                .Where(
                x => x.TransactionTypeId == TransactionType.Transaction ||
                x.TransactionTypeId == TransactionType.Payment)
                .ToList();

            return creditTransactionTypes;
        }

        private IEnumerable<TransactionType> getDebitTransactionTypes()
        {
            var debitTransactionTypes = _context.TransactionType
                .Where(
                x => x.TransactionTypeId == TransactionType.Transaction ||
                x.TransactionTypeId == TransactionType.Deposit ||
                x.TransactionTypeId == TransactionType.Transfer)
                .ToList();

            return debitTransactionTypes;
        }
    }
}