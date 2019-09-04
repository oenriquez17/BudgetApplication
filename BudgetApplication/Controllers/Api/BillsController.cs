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
using System.Web;
using System.Collections.Specialized;

namespace BudgetApplication.Controllers.Api
{
    public class BillsController : ApiController
    {
        private DatabaseContext _context;

        public BillsController()
        {
            _context = new DatabaseContext();
        }

        //Returns list of bills paid for current Month
        [HttpGet]
        public List<PaidBillsMap> GetPaidMonthlyBills()
        {
            NameValueCollection nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            int userId = Int32.Parse(nvc["userId"]);
            int month = Int32.Parse(nvc["month"]);
            int year = Int32.Parse(nvc["year"]);

            List<PaidBillsMap> paidBillsMap = new List<PaidBillsMap>();

            var query = from b in _context.MonthlyBill
                        join pb in _context.PaidBillsMap
                        on b.MonthlyBillId equals pb.MonthlyBillId
                        where b.UserId == userId &&
                        pb.Month == month &&
                        pb.Year == year
                        select new
                        {
                            b.MonthlyBillId,
                            pb.Month,
                            pb.Year
                        };

            foreach (var bill in query)
            {
                paidBillsMap.Add(new PaidBillsMap
                {
                    MonthlyBillId = bill.MonthlyBillId,
                    Month = bill.Month,
                    Year = bill.Year
                });
            }

            return paidBillsMap;
        }

        //POST /api/bills
        [HttpPost]
        public IHttpActionResult PayBill(PaidBillsMap paidBillsMap)
        {
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

        // DELETE /api/bills
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
