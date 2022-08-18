using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.Bills;
using FinancialTrackerMVC.Models.CreditCards;
using FinancialTrackerMVC.Models.MedicalAndInsurance;
using FinancialTrackerMVC.Models.Misc;
using FinancialTrackerMVC.Models.RentAndUtilities;
using FinancialTrackerMVC.Models.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.BillsService
{
    public class Bills : IBills
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public Bills(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateBillsAsync(BillsCreate model)
        {
            var bill = new BillsEntity
            {
                debtorName = model.debtorName
            };
            _dbContext.Bills.Add(bill);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<BillsDetail>> GetAllBillsAsync()
        {
            var bill = await _dbContext.Bills
            .Select(
                s => new BillsDetail
                {
                    id = s.id,
                    debtorName = s.debtorName
                }
            )
            .ToListAsync();
            return bill;
        }

        public async Task<BillsDetail> GetBillsByIdAsync(int id)
        {
            var billFound = await _dbContext.Bills.FindAsync(id);
            var subs = billFound.SubDebtors
            .Select(
                s => new SubscriptionsDetail{
                    id = s.id,
                    DebtorType = s.SubDebtorType,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            );
            var cred = billFound.CCDebtors
            .Select(
                c => new CreditCardsDetail{
                    id = c.id,
                    payoffAmount = c.payoffAmount,
                    DebtorType = c.CCDebtorType,
                    amountDue = c.amountDue,
                    dueDate = c.dueDate
                }
            );
            var medi = billFound.MIDebtors
            .Select(
                mi => new MedicalAndInsuranceDetail{
                    id = mi.id,
                    DebtorType = mi.MIDebtorType,
                    amountDue = mi.amountDue,
                    dueDate = mi.dueDate
                }
            );
            var renu = billFound.RUDebtors
            .Select(
                ru => new RentAndUtilitiesDetail{
                    id = ru.id,
                    DebtorType = ru.RUDebtorType,
                    amountDue = ru.amountDue,
                    dueDate = ru.dueDate
                }
            );
            var misc = billFound.MiscDebtors
            .Select(
                m => new MiscDetail{
                    id = m.id,
                    DebtorType = m.MiscDebtorType,
                    amountDue = m.amountDue,
                    dueDate = m.dueDate
                }
            );
            var bill = new BillsDetail{
                id = billFound.id,
                debtorName = billFound.debtorName,
                SubDebtorType = subs.ToList(),
                CCDebtorType = cred.ToList(),
                MIDebtorType = medi.ToList(),
                RUDebtorType = renu.ToList(),
                MiscDebtorDype = misc.ToList(),
            };
            return bill;
        }

        public async Task<bool> UpdateBillsAsync(int id, BillsUpdate request)
        {
            var bill = await _dbContext.Bills.FindAsync(id);
            if (bill is null)
            {
                return false;
            }
            bill.debtorName = request.debtorName;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteBillsAsync(int id)
        {
            var bill = await _dbContext.Bills.FindAsync(id);
            if (bill is null)
            {
                return false;
            }
            _dbContext.Bills.Remove(bill);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}