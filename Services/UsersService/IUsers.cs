using FinancialTrackerMVC.Models.Users;

namespace FinancialTrackerMVC.Services.UsersService
{
    public interface IUsers
    {
        Task<bool> RegisterUser(UsersRegister model);
        Task<IEnumerable<UsersDetail>> GetAllUsers();
        Task<UsersDetail> GetUserById(int id);
        Task<UsersDetail> GetUserByName(string fullName);
        Task<bool> UpdateUser(int id, UsersUpdate request);
        Task<bool> DeleteUser(string id);
    }
}