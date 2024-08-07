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
    public class SalonServiceManager : ISalonServiceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SalonServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalonService>> GetAllServicesAsync()
        {
            return await _repositoryManager.SalonService.GetAllServicesAsync(trackChanges: false);
        }

        public async Task<SalonService> GetServiceByIdAsync(int serviceId)
        {
            return await _repositoryManager.SalonService.GetServiceByIdAsync(serviceId, trackChanges: false);
        }

        public async Task CreateServiceAsync(SalonServiceDtoForInsertion salonServiceDto)
        {
            var entity = _mapper.Map<SalonService>(salonServiceDto);
            await _repositoryManager.SalonService.CreateServiceAsync(entity);
        }

        public async Task UpdateService(int id, SalonServiceDtoForInsertion salonServiceDto, bool trackChanges)
        {
            var entity = await GetOneSalonServiceByIdAndChechExits(id, trackChanges: trackChanges);


            _mapper.Map(salonServiceDto, entity);

            _repositoryManager.SalonService.UpdateService(entity);
        }

        public async Task DeleteService(int id, bool trackChanges)
        {
            var entity = await GetOneSalonServiceByIdAndChechExits(id, trackChanges: trackChanges);

            _repositoryManager.SalonService.DeleteService(entity);
        }

        public async Task<SalonService> GetOneSalonServiceByIdAndChechExits(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.SalonService.GetServiceByIdAsync(id, trackChanges);

            if (entity is null)

                throw new SalonServiceNotFoundException(id);

            return entity;



        }

    }
}


