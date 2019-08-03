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

        
        
    }
}
