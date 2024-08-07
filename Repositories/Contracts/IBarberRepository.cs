using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBarberRepository : IRepositoryBase<Barber>
    {
        Task<IEnumerable<Barber>> GetAllBarbersAsync(bool trackChanges);
        Task<Barber> GetBarberByIdAsync(int barberId, bool trackChanges);
        Task<Barber> GetBarberByNameAsync(string name, bool trackChanges);
        Task<IEnumerable<Barber>> GetBarbersByLocationAsync(string location, bool trackChanges);
        Task CreateBarberAsync(Barber barber);
        void UpdateBarber(Barber barber);
        void DeleteBarber(Barber barber);
    }
}
