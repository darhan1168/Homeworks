using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
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
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsersByRole(string role)
        {
            throw new NotImplementedException();
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