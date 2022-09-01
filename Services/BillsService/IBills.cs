using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Services.BillsService
{
    public interface IBills
    {
        Task<bool> CreateBill(BillsCreate model);
        Task<IEnumerable<BillsDetail>> GetAllBills();
        Task<BillsDetail> GetBillsById(int id);
        Task<bool> UpdateBill(int id, BillsUpdate request);
        Task<bool> DeleteBill(int id);
    }
}