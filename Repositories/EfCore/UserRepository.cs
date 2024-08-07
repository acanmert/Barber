using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
         await FindAll(trackChanges).ToListAsync();

        public async Task<User> GetUserByIdAsync(int userId, bool trackChanges) =>
            await FindByCondition(u => u.Id == userId, trackChanges).FirstOrDefaultAsync();

        public async Task<User> GetUserByEmailAsync(string email, bool trackChanges) =>
            await FindByCondition(u => u.Email == email, trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role, bool trackChanges) =>
            await FindByCondition(u => u.Role == role, trackChanges).ToListAsync();

        public async Task CreateUserAsync(User user)
        {
            await CreateAsync(user);
            await SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {
            Update(user);
            SaveChanges();
        }

        public void DeleteUser(User user)
        {
            Delete(user);
            SaveChanges();
        }


    }
}
