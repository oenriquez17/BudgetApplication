using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BudgetApplication.DAL;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using System.Data.Entity;
using System.Web.Http;

namespace BudgetApplication.Controllers.Api
{
    public class BillsController : ApiController
    {
        private DatabaseContext _context;

        public BillsController()
        {
            _context = new DatabaseContext();
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult PayBill(int id, int month, int year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                PaidBillsMap paidBillsMap = new PaidBillsMap();
                DateTime paidDate = new DateTime(year, month, 1);

                paidBillsMap.MonthlyBillId = id;
                paidBillsMap.PaidThisMonth = paidDate;

                _context.PaidBillsMap.Add(paidBillsMap);
                _context.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + id), paidBillsMap);
            }
        }

        // DELETE /api/bills/1
        [HttpDelete]
        public void UnpayBill(int id, int month, int year)
        {
            DateTime paidDate = new DateTime(year, month, 1);
            var billInDB = _context.PaidBillsMap
                .SingleOrDefault(b => b.MonthlyBillId == id 
                && b.PaidThisMonth.Month.Equals(paidDate.Month)
                && b.PaidThisMonth.Year.Equals(paidDate.Year));

            if (billInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                _context.PaidBillsMap.Remove(billInDB);
                _context.SaveChanges();
            }
        }
    }
}
