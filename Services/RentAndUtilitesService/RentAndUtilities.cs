using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.RentAndUtilities;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.RentAndUtilitiesService
{
    public class RentAndUtilities : IRentAndUtilities
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public RentAndUtilities(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateRentAndUtilitiesAsync(RentAndUtilitiesCreate model)
        {
            var renu = new RentAndUtilitiesEntity
            {
                //debtorName = model.debtorName.Subdebtor,
                amountDue = model.amountDue,
                dueDate = model.dueDate
            };
            _dbContext.RentAndUtilities.Add(renu);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<RentAndUtilitiesDetail>> GetAllRentAndUtilitiesAsync()
        {
            var renu = await _dbContext.RentAndUtilities
            .Select(
                s => new RentAndUtilitiesDetail
                {
                    id = s.id,
                    //debtorName = s.debtorName.SubDebtor,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .ToListAsync();
            return renu;
        }

        public async Task<RentAndUtilitiesDetail> GetRentAndUtilitiesByIdAsync(int id)
        {
            var renu = await _dbContext.RentAndUtilities
            .Select(
                s => new RentAndUtilitiesDetail
                {
                    id = s.id,
                    //debtorName = s.debtorName.SubDebtor,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .Where(
                s => s.id == id
            )
            .FirstOrDefaultAsync();
            return renu;
        }

        public async Task<bool> UpdateRentAndUtilitiesAsync(int id, RentAndUtilitiesUpdate request)
        {
            var renu = await _dbContext.RentAndUtilities.FindAsync(id);
            if (renu is null)
            {
                return false;
            }
            //renu.debtorName = request.debtorName.SubDebtor;
            renu.amountDue = request.amountDue;
            renu.dueDate = request.dueDate;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteRentAndUtilitiesAsync(int id)
        {
            var renu = await _dbContext.RentAndUtilities.FindAsync(id);
            if (renu is null)
            {
                return false;
            }
            _dbContext.RentAndUtilities.Remove(renu);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}