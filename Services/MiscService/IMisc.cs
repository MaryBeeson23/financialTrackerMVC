using FinancialTrackerMVC.Models.Misc;

namespace FinancialTrackerMVC.Services.MiscService
{
    public interface IMisc
    {
        Task<bool> CreateMiscAsync(MiscCreate model);
        Task<IEnumerable<MiscDetail>> GetAllMiscAsync();
        Task<MiscDetail> GetMiscByIdAsync(int id);
        Task<bool> UpdateMiscAsync(int id, MiscUpdate request);
        Task<bool> DeleteMiscAsync(int id);
    }
}