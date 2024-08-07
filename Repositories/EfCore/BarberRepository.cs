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
    internal class BarberRepository:RepositoryBase<Barber>,IBarberRepository
    {
        public BarberRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Barber>> GetAllBarbersAsync(bool trackChanges) =>
            await FindAll(trackChanges).ToListAsync();

        public async Task<Barber> GetBarberByIdAsync(int barberId, bool trackChanges) =>
            await FindByCondition(b => b.Id == barberId, trackChanges).FirstOrDefaultAsync();

        public async Task<Barber> GetBarberByNameAsync(string name, bool trackChanges) =>
            await FindByCondition(b => b.Name == name, trackChanges).FirstOrDefaultAsync();

        public async Task<IEnumerable<Barber>> GetBarbersByLocationAsync(string location, bool trackChanges) =>
            await FindByCondition(b => b.Location == location, trackChanges).ToListAsync();

        public async Task CreateBarberAsync(Barber barber)
        {
            await CreateAsync(barber);
            await SaveChangesAsync();
        }

        public void UpdateBarber(Barber barber)
        {
            Update(barber);
            SaveChanges();
        }

        public void DeleteBarber(Barber barber)
        {
            Delete(barber);
            SaveChanges();
        }
    }
}
