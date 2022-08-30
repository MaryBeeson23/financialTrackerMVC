using FinancialTrackerMVC.Models.Users;
using FinancialTrackerMVC.Data;
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

        public async Task<bool> RegisterUser(UsersRegister model)
        {
            if (model == null)
            {
                return false;
            }

            var user = new UserEntity
            {
                fullName = model.fullName,
                Email = model.email,
                // password = model.password,
            };
            // var passwordHasher = new PasswordHasher<UserEntity>();
            // user.password = passwordHasher.HashPassword(user, model.password);
            // _dbContext.Users.Add(user);
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<UsersDetail>> GetAllUsers()
        {
            var user = await _dbContext.ApplicationUsers
                .Select(
                    u => new UsersDetail
                    {
                        Id = u.Id,
                        fullName = u.fullName,
                        Email = u.Email,
                        income = u.income,
                        birthday = u.birthday
                    }
                ).ToListAsync();
                return user;
        }
        public async Task<UsersDetail> GetUserById(int id)
        {
            var user = await _dbContext.ApplicationUsers.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            var userDetail = new UsersDetail
            {
                Id = user.Id,
                fullName = user.fullName,
                Email = user.Email,
                income = user.income,
                birthday = user.birthday
            };
            return userDetail;
        }
        public async Task<UsersDetail> GetUserByName(string fullName)
        {
            var user = await _dbContext.ApplicationUsers.FindAsync(fullName);
            if (user is null)
            {
                return null;
            }
            var userDetail = new UsersDetail
            {
                Id = user.Id,
                fullName = user.fullName,
                Email = user.Email,
                income = user.income,
                birthday = user.birthday
            };
            return userDetail;
        }

        public async Task<bool> UpdateUser(int id, UsersUpdate request)
        {
            var user = await _dbContext.ApplicationUsers.FindAsync(id);
            if (user is null)
            {
                return false;
            }
            user.fullName = request.fullName;
            user.Email = request.email;
            // user.Password = request.password;
            user.income = request.income;
            user.birthday = request.birthday;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
            {
                return false;
            }
            _dbContext.Users.Remove(user);
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}