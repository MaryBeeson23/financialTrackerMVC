using FinancialTrackerMVC.Models.Bills;

namespace FinancialTrackerMVC.Services.BillsService
{
    public interface IBills
    {
        Task<bool> CreateBillsAsync(BillsCreate model);
        Task<IEnumerable<BillsDetail>> GetAllBillsAsync();
        Task<BillsDetail> GetBillsByIdAsync(int id);
        Task<bool> UpdateBillsAsync(int id, BillsUpdate request);
        Task<bool> DeleteBillsAsync(int id);
    }
}