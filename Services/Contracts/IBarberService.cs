using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBarberService
    {
        Task<IEnumerable<Barber>> GetAllBarbersAsync();
        Task<Barber> GetBarberByIdAsync(int barberId);
        Task<Barber> GetOneBarberByIdAndChechExits(int id, bool trackChanges);
        Task<Barber> CreateBarberAsync(BarberDtoForInsertion barberDto);
        Task UpdateBarber(int id,BarberDtoForInsertion barberDto, bool trackChanges);
        Task DeleteBarber(int id, bool trackChanges);
    }
}
