using FinancialTrackerMVC.Models.Users;
using FinancialTrackerMVC.Data;
using FinancialTrackerMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FinancialTrackerMVC.Services.UsersService
{
    public class Users : IUsers
    {
        private readonly FinancialTrackerDbContext _dbContext;
        public Users(FinancialTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUserAsync(UsersRegister model)
        {
            if (await GetUserByEmailAsync(model.email) != null || GetUserByNameAsync(model.fullName) != null)
            {
                return false;
            }

            var user = new UserEntity
            {
                fullName = model.fullName,
                email = model.email,
                password = model.password,
            };
            var passwordHasher = new PasswordHasher<UserEntity>();
            user.password = passwordHasher.HashPassword(user, model.password);
            _dbContext.Users.Add(user);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<UsersDetail>> GetAllUsersAsync()
        {
            var user = await _dbContext.Users
                .Select(
                    u => new UsersDetail
                    {
                        id = u.id,
                        fullName = u.fullName,
                        email = u.email,
                        income = u.income,
                        birthday = u.birthday
                    }
                ).ToListAsync();
                return user;
        }
        public async Task<UsersDetail> GetUserByIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            var userDetail = new UsersDetail
            {
                id = user.id,
                fullName = user.fullName,
                email = user.email,
                income = user.income,
                birthday = user.birthday
            };
            return userDetail;
        }
        public async Task<UsersDetail> GetUserByNameAsync(string fullName)
        {
            var user = await _dbContext.Users.FindAsync(fullName);
            if (user is null)
            {
                return null;
            }
            var userDetail = new UsersDetail
            {
                id = user.id,
                fullName = user.fullName,
                email = user.email,
                income = user.income,
                birthday = user.birthday
            };
            return userDetail;
        }

        public async Task<bool> UpdateUserAsync(int id, UsersUpdate request)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return false;
            }
            user.fullName = request.fullName;
            user.email = request.email;
            user.password = request.password;
            user.income = request.income;
            user.birthday = request.birthday;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return false;
            }
            _dbContext.Users.Remove(user);
            return await _dbContext.SaveChangesAsync() == 1;
        }



        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.email.ToLower() == email.ToLower());
        }
    }
}