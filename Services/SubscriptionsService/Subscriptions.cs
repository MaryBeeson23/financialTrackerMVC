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
            if (model == null)
            {
                return false;
            }
            _dbContext.Subscriptions.Add(new Data.Entities.SubscriptionsEntity
            {
                DebtorType = model.DebtorType,
            });

            if (await _dbContext.SaveChangesAsync() == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<SubscriptionsDetail>> GetAllSubscriptionsAsync()
        {
            var subs = await _dbContext.Subscriptions
            .Select(
                s => new SubscriptionsDetail
                {
                    // id = s.id,
                    SubDebtor = s.SubDebtor,
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
                    SubDebtor = s.SubDebtor,
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
            subs.SubDebtor = request.SubDebtor;
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