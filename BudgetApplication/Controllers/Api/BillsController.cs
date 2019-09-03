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

        //POST /api/bills
        [HttpPost]
        public IHttpActionResult PayBill(PaidBillsMap paidBillsMap)
        {
            System.Diagnostics.Debug.WriteLine(paidBillsMap.MonthlyBillId);
            System.Diagnostics.Debug.WriteLine(paidBillsMap.Month);
            System.Diagnostics.Debug.WriteLine(paidBillsMap.Year);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.PaidBillsMap.Add(paidBillsMap);
                _context.SaveChanges();

                return Created(new Uri(Request.RequestUri + "/" + paidBillsMap.PaidBillsMapId), paidBillsMap);
            }
        }

        // DELETE /api/bills/1
        [HttpDelete]
        public void UnpayBill(PaidBillsMap paidBillsMap)
        {
            var billInDB = _context.PaidBillsMap
                .SingleOrDefault(b => b.MonthlyBillId == paidBillsMap.MonthlyBillId
                && b.Month == paidBillsMap.Month
                && b.Year == paidBillsMap.Year);

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
