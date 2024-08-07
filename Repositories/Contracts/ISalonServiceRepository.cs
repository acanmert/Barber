using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ISalonServiceRepository : IRepositoryBase<SalonService>
    {
        Task<IEnumerable<SalonService>> GetAllServicesAsync(bool trackChanges);
        Task<SalonService> GetServiceByIdAsync(int serviceId, bool trackChanges);
        Task<IEnumerable<SalonService>> GetServicesByCategoryAsync(string category, bool trackChanges);
        Task CreateServiceAsync(SalonService service);
        void UpdateService(SalonService service);
        void DeleteService(SalonService service);
    }
}
