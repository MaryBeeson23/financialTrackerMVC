using FinancialTrackerMVC.Models.CreditCards;

namespace FinancialTrackerMVC.Services.CreditCardsService
{
    public interface ICreditCards
    {
        Task<bool> CreateCreditCardsAsync(CreditCardsCreate model);
        Task<IEnumerable<CreditCardsDetail>> GetAllCreditCardsAsync();
        Task<CreditCardsDetail> GetCreditCardsByIdAsync(int id);
        Task<bool> UpdateCreditCardsAsync(int id, CreditCardsUpdate request);
        Task<bool> DeleteCreditCardsAsync(int id);
    }
}