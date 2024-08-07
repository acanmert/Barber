using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAppointmentRepository:IRepositoryBase<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges);
        Task<IEnumerable<Appointment>> GetAppointmentsByUserIdAsync(int userId, bool trackChanges);
        Task<IEnumerable<Appointment>> GetAppointmentsByBarberIdAsync(int barberId, bool trackChanges);
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId, bool trackChanges);
        Task CreateAppointmentAsync(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(Appointment appointment);
    }
}
