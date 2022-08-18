using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.Subscriptions;
// using FinancialTrackerMVC.Models.Bills;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.SubscriptionsService
{
    public class Subscriptions : ISubscriptions
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public Subscriptions(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateSubscriptionAsync(SubscriptionsCreate model)
        {
            var subs = new SubscriptionsEntity
            {
                SubDebtorType = model.DebtorType,
                amountDue = model.amountDue,
                dueDate = model.dueDate
            };
            _dbContext.Subscriptions.Add(subs);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<SubscriptionsDetail>> GetAllSubscriptionsAsync()
        {
            var subs = await _dbContext.Subscriptions
            .Select(
                s => new SubscriptionsDetail
                {
                    id = s.id,
                    DebtorType = s.SubDebtorType,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .ToListAsync();
            return subs;
        }

        public async Task<SubscriptionsDetail> GetSubscriptionsByIdAsync(int id)
        {
            var subs = await _dbContext.Subscriptions
            .Select(
                s => new SubscriptionsDetail
                {
                    id = s.id,
                    DebtorType = s.SubDebtorType,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .Where(
                s => s.id == id
            )
            .FirstOrDefaultAsync();
            return subs;
        }

        public async Task<bool> UpdateSubscriptionsAsync(int id, SubscriptionsUpdate request)
        {
            var subs = await _dbContext.Subscriptions.FindAsync(id);
            if (subs is null)
            {
                return false;
            }
            subs.SubDebtorType = request.DebtorType;
            subs.amountDue = request.amountDue;
            subs.dueDate = request.dueDate;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteSubscriptionsAsync(int id)
        {
            var subs = await _dbContext.Subscriptions.FindAsync(id);
            if (subs is null)
            {
                return false;
            }
            _dbContext.Subscriptions.Remove(subs);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}