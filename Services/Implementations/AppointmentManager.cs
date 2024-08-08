using AutoMapper;
using Entities.Dto;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

public class AppointmentManager : IAppointmentService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IBarberService _barberService;

    public AppointmentManager(IRepositoryManager repositoryManager, IMapper mapper, IUserService userService, IBarberService barberService)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _userService = userService;
        _barberService = barberService;
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

    public async Task<Appointment> GetOneAppointmentByIdAndChechExits(int appointmentId, bool trackChanges)
    {
        var entity = await _repositoryManager.Appointment.GetAppointmentByIdAsync(appointmentId, trackChanges);
        if (entity is null)
            throw new AppointmentNotFoundException(appointmentId);
        return entity;
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentByUserIdAsync(int userId, bool trackChanges)
    {
        var user = await _userService.GetOneUserByIdAndChechExits(userId, trackChanges);

        var appointment = await _repositoryManager.Appointment.GetAppointmentsByUserIdAsync(userId, trackChanges);
        if (appointment is null)
        {
            throw new NotFoundObject("Empty");
        }
        return appointment;

    }

    public async Task<IEnumerable<Appointment>> GetAppointmentByBarberIdAsync(int barberId, bool trackChanges)
    {
        var barber = await _barberService.GetOneBarberByIdAndChechExits(barberId,trackChanges);
        var appointment=await _repositoryManager.Appointment.GetAppointmentsByBarberIdAsync(barberId, trackChanges);
        if(appointment is null)
        {
            throw new NotFoundObject("Empty");
        }
        return appointment;
    }
}
