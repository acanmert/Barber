using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserByIdAsync(int userId, bool trackChanges);
        Task<User> GetUserByEmailAsync(string email, bool trackChanges);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role, bool trackChanges);
        Task CreateUserAsync(User user); 
        void UpdateUser(User user); 
        void DeleteUser(User user); 
    }
}
