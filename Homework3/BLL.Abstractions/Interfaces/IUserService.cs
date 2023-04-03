using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Abstractions.Interfaces
{
    // Authenticate: Verifies the provided username and password, returning the user if the authentication is successful.
    // GetUserByUsername: Retrieves a user by their username.
    // GetUsersByRole: Retrieves a list of users based on the specified role (e.g., client, trainer, or administrator).
    // UpdatePassword: Updates the user's password.
    // ResetPassword: Resets the user's password to a default value or generates a new temporary password.
    // LockUser: Locks the user's account, preventing them from logging in to the system.
    // UnlockUser: Unlocks the user's account, allowing them to log in to the system.
    public interface IUserService : IGenericService<User>
    {
        Task<User> Authenticate(string username, string password);
        
        Task<User> GetUserByUsername(string username);
        
        Task<List<User>> GetUsersByRole(string role);
        
        Task UpdatePassword(Guid userId, string newPassword);
        
        Task ResetPassword(Guid userId);
        
        Task LockUser(Guid userId);
        
        Task UnlockUser(Guid userId);
    }
}