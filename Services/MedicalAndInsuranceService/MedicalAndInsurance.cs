using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using FinancialTrackerMVC.Models.MedicalAndInsurance;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrackerMVC.Services.MedicalAndInsuranceService
{
    public class MedicalAndInsurance : IMedicalAndInsurance
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public MedicalAndInsurance(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateMedicalAndInsuranceAsync(MedicalAndInsuranceCreate model)
        {
            var medi = new MedicalAndInsuranceEntity
            {
                //debtorName = model.debtorName.Subdebtor,
                amountDue = model.amountDue,
                dueDate = model.dueDate
            };
            _dbContext.MedicalAndInsurance.Add(medi);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<MedicalAndInsuranceDetail>> GetAllMedicalAndInsuranceAsync()
        {
            var medi = await _dbContext.MedicalAndInsurance
            .Select(
                s => new MedicalAndInsuranceDetail
                {
                    id = s.id,
                    //debtorName = s.debtorName.SubDebtor,
                    amountDue = s.amountDue,
                    dueDate = s.dueDate
                }
            )
            .ToListAsync();
            return medi;
        }

        public async Task<MedicalAndInsuranceDetail> GetMedicalAndInsuranceByIdAsync(int id)
        {
            var medi = await _dbContext.MedicalAndInsurance
            .Select(
                s => new MedicalAndInsuranceDetail
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
            return medi;
        }

        public async Task<bool> UpdateMedicalAndInsuranceAsync(int id, MedicalAndInsuranceUpdate request)
        {
            var medi = await _dbContext.MedicalAndInsurance.FindAsync(id);
            if (medi is null)
            {
                return false;
            }
            //medi.debtorName = request.debtorName.SubDebtor;
            medi.amountDue = request.amountDue;
            medi.dueDate = request.dueDate;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteMedicalAndInsuranceAsync(int id)
        {
            var medi = await _dbContext.MedicalAndInsurance.FindAsync(id);
            if (medi is null)
            {
                return false;
            }
            _dbContext.MedicalAndInsurance.Remove(medi);
            return await _dbContext.SaveChangesAsync() == 1;
        }
        
    }
}