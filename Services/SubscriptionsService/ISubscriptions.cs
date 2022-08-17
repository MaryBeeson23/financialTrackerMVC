using FinancialTrackerMVC.Models.Subscriptions;

namespace FinancialTrackerMVC.Services.SubscriptionsService
{
    public interface ISubscriptions
    {
        Task<bool> CreateSubscriptionAsync(SubscriptionsCreate model);
        Task<IEnumerable<SubscriptionsDetail>> GetAllSubscriptionsAsync();
        Task<SubscriptionsDetail> GetSubscriptionsByIdAsync(int id);
        Task<bool> UpdateSubscriptionsAsync(int id, SubscriptionsUpdate request);
        Task<bool> DeleteSubscriptionsAsync(int id);
    }
}