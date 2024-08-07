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
    public class BarberManager : IBarberService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;


        public BarberManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Barber>> GetAllBarbersAsync()
        {
            return await _repositoryManager.Barber.GetAllBarbersAsync(trackChanges: false);
        }

        public async Task<Barber> GetBarberByIdAsync(int barberId)
        {
            return await _repositoryManager.Barber.GetBarberByIdAsync(barberId, trackChanges: false);
        }

        public async Task<Barber> CreateBarberAsync(BarberDtoForInsertion barberDto)
        {
            var entity = _mapper.Map<Barber>(barberDto);
            await _repositoryManager.Barber.CreateBarberAsync(entity);
            return entity;
        }

        public async Task UpdateBarber(int id, BarberDtoForInsertion barberDto, bool trackChanges)
        {
            var entity = await GetOneBarberByIdAndChechExits(id, trackChanges);
            _mapper.Map(barberDto, entity);

            _repositoryManager.Barber.UpdateBarber(entity);
        }

        public async Task DeleteBarber(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.Barber.GetBarberByIdAsync(id, trackChanges);
            if (entity == null)
            {
                throw new Exception($"Barber with id {id} not found.");
            }

            _repositoryManager.Barber.DeleteBarber(entity);


        }

        public async Task<Barber> GetOneBarberByIdAndChechExits(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.Barber.GetBarberByIdAsync(id, trackChanges);

            if (entity is null)

                throw new BarberNotFoundException(id);

            return entity;



        }
    }
}
