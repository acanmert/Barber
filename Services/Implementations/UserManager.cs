using AutoMapper;
using Entities.Dto;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UserManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repositoryManager.User.GetAllUsersAsync(trackChanges: false);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _repositoryManager.User.GetUserByIdAsync(userId, trackChanges: false);
        }

        public async Task<User> CreateUserAsync(UserForRegistrationDto userDto)
        {
            var entity=_mapper.Map<User>(userDto);
            await _repositoryManager.User.CreateUserAsync(entity);
            return entity;
        }

        public async Task UpdateUser(int id,UserForRegistrationDto userDto, bool trackChanges)
        {
            var entity = await GetOneUserByIdAndChechExits(id,false);
            _mapper.Map(userDto, entity);


            _repositoryManager.User.UpdateUser(entity);
        }

        public async Task DeleteUser(int id ,bool trackChanges)
        {
            var entity = await GetOneUserByIdAndChechExits(id, trackChanges);
 
            _repositoryManager.User.DeleteUser(entity);
        }

        public async Task<User> GetUserByEmailAsync(string email,bool trackChanges)
        {
            var entity=await _repositoryManager.User.GetUserByEmailAsync(email,trackChanges);
            return entity;
        }

        public async Task<User> GetOneUserByIdAndChechExits(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.User.GetUserByIdAsync(id, trackChanges);

            if (entity is null)

                throw new UserNotFoundException(id);

            return entity;



        }

    }
}
