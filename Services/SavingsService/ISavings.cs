using FinancialTrackerMVC.Models.Savings;

namespace FinancialTrackerMVC.Services.SavingsService
{
    public interface ISavings
    {
        Task<bool> CreateSavingsAsync(SavingsCreate model);
        Task<IEnumerable<SavingsDetail>> GetAllSavingsAsync();
        Task<SavingsDetail> GetSavingsByIdAsync(int id);
        Task<bool> UpdateSavingsAsync(int id, SavingsUpdate request);
        Task<bool> DeleteSavingsAsync(int id);
    }
}