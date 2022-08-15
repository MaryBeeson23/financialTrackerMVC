using FinancialTrackerMVC.Models.Users;

namespace FinancialTrackerMVC.Services.UsersService
{
    public interface IUsers
    {
        Task<bool> RegisterUserAsync(UsersRegister model);
        Task<IEnumerable<UsersDetail>> GetAllUsersAsync();
        Task<UsersDetail> GetUserByIdAsync(int id);
        Task<UsersDetail> GetUserByNameAsync(string fullName);
        Task<bool> UpdateUserAsync(int id, UsersUpdate request);
        Task<bool> DeleteUserAsync(int id);
    }
}