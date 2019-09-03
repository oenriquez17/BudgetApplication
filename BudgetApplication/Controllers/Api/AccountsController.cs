using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetApplication.Models;
using BudgetApplication.DAL;

namespace BudgetApplication.Controllers.Api
{
    public class AccountsController : ApiController
    {
        DatabaseContext _context;

        public AccountsController()
        {
            _context = new DatabaseContext();
        }

        // GET api/accounts
        public IEnumerable<Account> GetAccounts()
        {
            return _context.Account.ToList();
        }


        // DELETE /api/accounts/1
        [HttpDelete]
        public void DeleteAccount(int id)
        {
            var accountsInDB = _context.Account.SingleOrDefault(a => a.AccountId == id);

            if (accountsInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.Account.Remove(accountsInDB);
                _context.SaveChanges();
            }
        }
    }
}
