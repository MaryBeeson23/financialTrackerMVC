using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.Bills;
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
                //debtorName = model.debtorName.Subdebtor,
                billType = model.billType,
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
                    //debtorName = s.debtorName.SubDebtor,
                    billType = s.billType,
                    debtorName = s.debtorName
                }
            )
            .ToListAsync();
            return bill;
        }

        public async Task<BillsDetail> GetBillsByIdAsync(int id)
        {
            var bill = await _dbContext.Bills
            .Select(
                s => new BillsDetail
                {
                    id = s.id,
                    //debtorName = s.debtorName.SubDebtor,
                    billType = s.billType,
                    debtorName = s.debtorName
                }
            )
            .Where(
                s => s.id == id
            )
            .FirstOrDefaultAsync();
            return bill;
        }

        public async Task<bool> UpdateBillsAsync(int id, BillsUpdate request)
        {
            var bill = await _dbContext.Bills.FindAsync(id);
            if (bill is null)
            {
                return false;
            }
            //bill.debtorName = request.debtorName.SubDebtor;
            bill.billType = request.billType;
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