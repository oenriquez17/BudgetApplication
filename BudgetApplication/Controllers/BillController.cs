using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetApplication.DAL;
using BudgetApplication.Models;
using BudgetApplication.ViewModels;
using System.Data.Entity;
using BudgetApplication.SessionAuth;

namespace BudgetApplication.Controllers
{
    public class BillController : Controller
    {
        private DatabaseContext _context;

        public BillController()
        {
            _context = new DatabaseContext();
        }
        
        // GET: Bill
        [CheckSession]
        public ActionResult Index()
        {
            int userId = (int)Session["userId"];

            var bills = GetMonthlyBills(userId);
            var paidBills = GetPaidMonthlyBills(userId);

            var viewModel = new BillsViewModel
            {
                AllBills = bills,
                PaidBills = paidBills
            };

            return View(viewModel);
        }

        [CheckSession]
        public ActionResult BillForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveBill(MonthlyBill monthlyBill)
        {
            int userId = (int)Session["userId"];

            _context.MonthlyBill.Add(new MonthlyBill
            {
                MonthlyBillName = monthlyBill.MonthlyBillName,
                UserId = userId
            });

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Returns list of bills
        private List<MonthlyBill> GetMonthlyBills(int userId)
        {
            List<MonthlyBill> monthlyBills = new List<MonthlyBill>();

            var query = from b in _context.MonthlyBill
                        where b.UserId == userId
                        select new
                        {
                            b.MonthlyBillId,
                            b.MonthlyBillName,
                        };

            foreach (var bill in query)
            {
                monthlyBills.Add(new MonthlyBill
                {
                    MonthlyBillId = bill.MonthlyBillId,
                    MonthlyBillName = bill.MonthlyBillName
                });
            }

            return monthlyBills;
        }

        //Returns list of bills paid
        private List<PaidBillsMap> GetPaidMonthlyBills(int userId)
        {
            List<PaidBillsMap> paidBillsMap = new List<PaidBillsMap>();

            var query = from b in _context.MonthlyBill
                        join pb in _context.PaidBillsMap
                        on b.MonthlyBillId equals pb.MonthlyBillId
                        where b.UserId == userId
                        select new
                        {
                            b.MonthlyBillId,
                            pb.Month,
                            pb.Year
                        };

            foreach(var bill in query)
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
    }
}