using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISalonServiceService
    {
        Task<IEnumerable<SalonService>> GetAllServicesAsync();
        Task<SalonService> GetServiceByIdAsync(int serviceId);
        Task<SalonService> GetOneSalonServiceByIdAndChechExits(int id, bool trackChanges);
        Task CreateServiceAsync(SalonServiceDtoForInsertion salonServiceDto);
        Task UpdateService(int id, SalonServiceDtoForInsertion salonServiceDto, bool trackChanges);
        Task DeleteService(int id, bool trackChanges);
    }
}
