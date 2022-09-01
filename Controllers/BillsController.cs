using Microsoft.AspNetCore.Mvc;
using FinancialTrackerMVC.Models.Bills;
using FinancialTrackerMVC.Services.BillsService;
using FinancialTrackerMVC.Services.SubscriptionsService;

namespace FinancialTrackerMVC.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBills _billsService;
        private readonly ISubscriptions _subService;
        public BillsController(IBills billsService, ISubscriptions subsService)
        {
            _billsService = billsService;
            _subService = subsService;
        }

        public async Task<IActionResult> Index()
        {
            var bills = await _billsService.GetAllBills();
            return View(bills);
        }

        public async Task<IActionResult> Details(int id)
        {
            var bills = await _billsService.GetBillsById(id);

            if (bills == null)
            {
                return NotFound();
            }

            return View(bills);
        }

        public async Task<IActionResult> Create()
        {
            var bills = await _billsService.GetAllBills();

            IEnumerable<BillsCreate> model = bills
                .Select(b => new BillsCreate()
            {
                id = b.id,
                debtorName = b.debtorName

            });

            return View(model);
        }
    

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillsCreate model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(ModelState);
            }

            bool wasReg = await _billsService.CreateBill(model);

            if (wasReg)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var bills = await _billsService.GetAllBills();

            IEnumerable<BillsDetail> bill = bills
                .Select(b => new BillsDetail()
                {
                    id = b.id,
                    debtorName = b.debtorName
                });

            BillsDetail billId = await _billsService.GetBillsById(id);

            if (bills == null)
            {
                return NotFound();
            }

            var billsDetail = new BillsDetail();

            return View(billsDetail);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(int id, BillsUpdate model)
        {
            if (id != model.id || !ModelState.IsValid)
            {
                return View(ModelState);
            }

            bool wasUpdated = await _billsService.UpdateBill(id, model);

            if (wasUpdated)
            {
                return RedirectToAction("Details", new { id = model.debtorName });
            }

            ViewData["ErrorMsg"] = "Unable to save to the database. Please try again later.";

            return View(model);
        }

        // [HttpDelete]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var bills = await _billsService.GetBillById(id);

        //     if (bills == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(bills);
        // }

        [HttpDelete]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, BillsDetail model)
        {
            if (await _billsService.DeleteBill(model.id))
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}