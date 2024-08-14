using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByEmailAsync(string email, bool trackChanges);
        Task<User> GetOneUserByIdAndChechExits(int id,bool trackChanges);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> CreateUserAsync(UserForRegistrationDto userDto);
        Task UpdateUser(int id, UserForRegistrationDto userDto, bool trackChanges);
        Task DeleteUser(int id, bool trackChanges);
    }
}
