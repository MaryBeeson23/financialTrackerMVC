using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinancialTrackerMVC.Models.Bills
{
    public class BillsCreate
    {
        public int id { get; set; }
        public string debtorName { get; set; }
        public enum SubDebtorType
        {
            Netflix, Youtube, Hulu
        }

        public IEnumerable<SelectListItem> subBill { get; set; } = new List<SelectListItem>();

    }
}