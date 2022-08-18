using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.Misc;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.MiscService
{
    public class Misc : IMisc
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public Misc(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMiscAsync(MiscCreate model)
        {
            var misc = new MiscEntity
            {
                //debtorName = model.debtorName.Subdebtor,
                amountDue = model.amountDue,
                dueDate = model.dueDate
            };
            _dbContext.Misc.Add(misc);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<MiscDetail>> GetAllMiscAsync()
        {
            var misc = await _dbContext.Misc
            .Select(
                s => new MiscDetail
                {
                    id = s.id,
                    //debtorName = s.debtorName.SubDebtor,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .ToListAsync();
            return misc;
        }

        public async Task<MiscDetail> GetMiscByIdAsync(int id)
        {
            var misc = await _dbContext.Misc
            .Select(
                s => new MiscDetail
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
            return misc;
        }

        public async Task<bool> UpdateMiscAsync(int id, MiscUpdate request)
        {
            var misc = await _dbContext.Misc.FindAsync(id);
            if (misc is null)
            {
                return false;
            }
            //misc.debtorName = request.debtorName.SubDebtor;
            misc.amountDue = request.amountDue;
            misc.dueDate = request.dueDate;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteMiscAsync(int id)
        {
            var misc = await _dbContext.Misc.FindAsync(id);
            if (misc is null)
            {
                return false;
            }
            _dbContext.Misc.Remove(misc);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}