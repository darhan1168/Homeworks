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
            throw new NotImplementedException();
        }

        public async Task ResetPassword(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task LockUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task UnlockUser(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}