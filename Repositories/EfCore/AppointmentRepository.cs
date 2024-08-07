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
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(a => a.Date)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(int userId, bool trackChanges) =>
           await FindByCondition(a => a.UserId == userId, trackChanges).ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByBarberIdAsync(int barberId, bool trackChanges) =>
            await FindByCondition(a => a.BarberId == barberId, trackChanges).ToListAsync();

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId, bool trackChanges) =>
            await FindByCondition(a => a.Id == appointmentId, trackChanges).FirstOrDefaultAsync();
        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await CreateAsync(appointment);
            await SaveChangesAsync();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            Update(appointment);
            SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            Delete(appointment);
            SaveChanges();
        }
    }
}
