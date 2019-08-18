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
                CreditTransactionTypes = creditTransactionTypes,
                TransactionDate = DateTime.Now
            };

            //Given the list of accounts, the user will be able to selecte accounts
            return View(transactionFormViewModel);
        }


        [HttpPost]
        public ActionResult ProcessTransaction(NewTransactionViewModel model)
        {
            //---- Variables ------//
            int primaryAccountId = model.SelectedPrimaryAccountId;
            int targetAccountId = model.SelectedTargetAccountId;
            double transactionAmount = model.TransactionAmount;
            string comment = model.Comment;
            DateTime transactionDate = model.TransactionDate;
            string op = TransactionType.Add; // Add is default

            int transactionTypeId = 0;
            //Debit Transaction Type
            if (model.SelectedDebitTransactionType != null)
            {
                transactionTypeId = Int32.Parse(model.SelectedDebitTransactionType);
                if (transactionTypeId.Equals(TransactionType.Deposit.ToString()))
                {
                    //Add amount
                    op = TransactionType.Add;
                }
                else
                {
                    //substract amount
                    op = TransactionType.Substract;
                }
            }
            //Credit Transaction Type
            else
            {
                transactionTypeId = Int32.Parse(model.SelectedCreditTransactionType);
                if(transactionTypeId.Equals(TransactionType.Payment.ToString()))
                {
                    //subtract amount
                    op = TransactionType.Substract;
                } else
                {
                    //add amount
                    op = TransactionType.Add;
                }
            }

            //Create Transaction
            createTransaction(primaryAccountId, transactionTypeId,
                transactionAmount, transactionDate, comment);

            //Create 2nd Transasction if TransactionType is Transfer
            int targetAccountTypeId = 0;
            if (targetAccountId != 0)
            {
                //check targetAccountType
                targetAccountTypeId = retrieveAccountTypeIdByAccountId(targetAccountId);
                if(targetAccountTypeId == AccountType.CreditCard)
                {
                    createTransaction(targetAccountId, TransactionType.Payment, transactionAmount,
                        transactionDate, comment);
                } else
                {
                    createTransaction(targetAccountId, TransactionType.Deposit, transactionAmount,
                        transactionDate, comment);
                }
            }

            bool updateRes = updateAccountBalance(primaryAccountId, transactionAmount, op);
            if(targetAccountId != 0)
            {
                if (targetAccountTypeId == AccountType.CreditCard)
                {
                    updateAccountBalance(targetAccountId, transactionAmount, TransactionType.Substract);
                }
                else
                {
                    updateAccountBalance(targetAccountId, transactionAmount, TransactionType.Add);
                }

            }

            return Content("TEST");
        }

        private int retrieveAccountTypeIdByAccountId(int AccountId)
        {
            var account = _context.Account.SingleOrDefault(x => x.AccountId == AccountId);
            if(account != null)
            {
                return account.AccountTypeId;
            } else
            {
                return 0;
            }
        }

        private void createTransaction(int AccountId, int TransactionTypeId, double Amount, 
            DateTime TransactionDate, string Comment)
        {
            var newTransaction = new Transaction
            {
                TransactionTypeId = TransactionTypeId,
                AccountId = AccountId,
                Amount = Amount,
                DateOfTransaction = TransactionDate,
                Comments = Comment
            };

            _context.Transaction.Add(newTransaction);
            _context.SaveChanges();
        }

        // Checks if UserID - AccountID record exists
        private bool verifyAccountUser(int AccountId, int UserId)
        {
            bool retVal = false;
            retVal = _context.AccountUser.Any(x => x.AccountId == AccountId && x.UserId == UserId);
            return retVal;
        }

        private bool updateAccountBalance(int AccountId, double TransactionAmount, string Op)
        {
            bool retVal = false;
            var account = _context.Account.SingleOrDefault(x => x.AccountId == AccountId);
            if(account != null)
            {
                account.AccountId = account.AccountId;
                account.AccountName = account.AccountName;
                account.AccountTypeId = account.AccountTypeId;
                double currentBalance = account.Balance;

                if (Op.Equals(TransactionType.Add))
                {
                    currentBalance += TransactionAmount;
                } else
                {
                    currentBalance -= TransactionAmount;
                }

                account.Balance = currentBalance;

                _context.SaveChanges();
                retVal = true;
            }

            return retVal;
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