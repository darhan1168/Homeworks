using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Enums;
using Core.Models;
using DAL.Abstractions.Interfaces;

namespace BLL.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        public UserService(IRepository<User> repository) :
            base(repository)
        {
        }

        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                var user = await GetUserByUsername(username);

                if (user is null)
                {
                    throw new Exception("User is null");
                }

                if (user.IsLocked)
                {
                    throw new Exception("User is locked");
                }

                if (user.PasswordHash == password)
                {
                    return user;
                }

                throw new Exception("Password is not correct");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to authenticate {username} and {password}. Exception: {ex.Message}");
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var users = await GetAll();

                if (users is null)
                {
                    throw new Exception("Users are null");
                }

                foreach (var user in users)
                {
                    if (user.Username == username)
                    {
                        return user;
                    }
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get user by username {username}. Exception: {ex.Message}");
            }
        }

        public async Task<List<User>> GetUsersByRole(string role)
        {
            try
            {
                var users = await GetAll();

                if (users is null)
                {
                    throw new Exception("Users are null");
                }

                UserRole avaibleRole;

                switch (role)
                {
                    case "Admin":
                        avaibleRole = UserRole.Admin;
                        break;
                    case "Trainer":
                        avaibleRole = UserRole.Trainer;
                        break;
                    case "Member":
                        avaibleRole = UserRole.Member;
                        break;
                    default:
                        throw new Exception("Incorrect role");
                }

                return users.Where(u => u.Role == avaibleRole).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get user by role {role}. Exception: {ex.Message}");
            }
        }

        public async Task UpdatePassword(Guid userId, string newPassword)
        {
            try
            {
                var user = await GetById(userId);

                if (user is null)
                {
                    throw new Exception("User is null");
                }

                if (user.PasswordHash == newPassword)
                {
                    throw new Exception("New password equals previous password");
                }

                user.PasswordHash = newPassword;

                await Update(userId, user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update password {newPassword}. Exception: {ex.Message}");
            }
        }

        public async Task ResetPassword(Guid userId)
        {
            try
            {
                var user = await GetById(userId);

                if (user is null)
                {
                    throw new Exception("User is null");
                }

                user.PasswordHash = GeneratePassword();

                await Update(userId, user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to reset password {userId}. Exception: {ex.Message}");
            }
        }

        public async Task LockUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UnlockUser(Guid userId)
        {
            throw new NotImplementedException();
        }
        
        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new string(
                Enumerable.Repeat(chars, 8)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            return password;
        }
    }
}