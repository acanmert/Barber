
using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int appointmentId);
        Task<IEnumerable<Appointment>> GetAppointmentByUserIdAsync(int userId, bool trackChanges);
        Task<Appointment> GetOneAppointmentByIdAndChechExits(int appointmentId, bool trackChanges);


        Task<IEnumerable<Appointment>> GetAppointmentByBarberIdAsync(int barberId,bool trackChanges);

        Task CreateAppointmentAsync(AppointmentDtoForInsertion appointmentDto);
        Task UpdateAppointment(int id,AppointmentDtoForInsertion appointmentDto, bool trackChanges);
        Task DeleteAppointment(int id, bool trackChanges);
    }
}
