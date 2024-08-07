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
    public class SalonServiceRepository : RepositoryBase<SalonService>, ISalonServiceRepository
    {
        public SalonServiceRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SalonService>> GetAllServicesAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<SalonService> GetServiceByIdAsync(int serviceId, bool trackChanges) =>
            await FindByCondition(s => s.Id == serviceId, trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<SalonService>> GetServicesByCategoryAsync(string category, bool trackChanges) =>
            await FindByCondition(s => s.Category == category, trackChanges).ToListAsync();
        public async Task CreateServiceAsync(SalonService service)
        {
            await CreateAsync(service);
            await SaveChangesAsync();
        }

        public void UpdateService(SalonService service)
        {
            Update(service);
            SaveChanges();
        }

        public void DeleteService(SalonService service)
        {
            Delete(service);
            SaveChanges();
        }

    }
}
