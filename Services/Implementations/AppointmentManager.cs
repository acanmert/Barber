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
    public class AppointmentManager : IAppointmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AppointmentManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _repositoryManager.Appointment.GetAllAppointmentsAsync(trackChanges: false);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int appointmentId)
        {
            return await _repositoryManager.Appointment.GetAppointmentByIdAsync(appointmentId, trackChanges: false);
        }

        public async Task CreateAppointmentAsync(AppointmentDtoForInsertion appointmentDtoForInsertion)
        {
            var entity = _mapper.Map<Appointment>(appointmentDtoForInsertion);

            await _repositoryManager.Appointment.CreateAppointmentAsync(entity);
        }

        public async Task UpdateAppointment(int id, AppointmentDtoForInsertion appointmentDto, bool trackChanges)
        {
            var entity = await GetOneAppointmentByIdAndChechExits(id, trackChanges);

            _mapper.Map(appointmentDto, entity);
            _repositoryManager.Appointment.UpdateAppointment(entity);
        }

        public async Task DeleteAppointment(int id, bool trackChanges)
        {
            var entity = await GetOneAppointmentByIdAndChechExits(id, trackChanges);
            _repositoryManager.Appointment.DeleteAppointment(entity);
        }

        public async Task<Appointment> GetOneAppointmentByIdAndChechExits(int id, bool trackChanges)
        {
            var entity = await _repositoryManager.Appointment.GetAppointmentByIdAsync(id, trackChanges);

            if (entity is null)

                throw new AppointmentNotFoundException(id);

            return entity;

        }
    }
}

