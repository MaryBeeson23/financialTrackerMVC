using FinancialTrackerMVC.Models.MedicalAndInsurance;

namespace FinancialTrackerMVC.Services.MedicalAndInsuranceService
{
    public interface IMedicalAndInsurance
    {
        Task<bool> CreateMedicalAndInsuranceAsync(MedicalAndInsuranceCreate model);
        Task<IEnumerable<MedicalAndInsuranceDetail>> GetAllMedicalAndInsuranceAsync();
        Task<MedicalAndInsuranceDetail> GetMedicalAndInsuranceByIdAsync(int id);
        Task<bool> UpdateMedicalAndInsuranceAsync(int id, MedicalAndInsuranceUpdate request);
        Task<bool> DeleteMedicalAndInsuranceAsync(int id);
    }
}