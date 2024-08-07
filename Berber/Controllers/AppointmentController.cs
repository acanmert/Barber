using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IServiceManager _services;

        public AppointmentController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _services.AppointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var appointment = await _services.AppointmentService.GetAppointmentByIdAsync(id);
            
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDtoForInsertion appointmentDto)
        {
             await _services.AppointmentService.CreateAppointmentAsync(appointmentDto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int id, [FromBody] AppointmentDtoForInsertion appointmentDto)
        {
            await _services.AppointmentService.UpdateAppointment(id, appointmentDto, false);
            return Ok(appointmentDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            await _services.AppointmentService.DeleteAppointment(id, false);
            return NoContent(); // 204 No Content döner, çünkü başarıyla silindiğinde içeriğe gerek yok.
        }
    }
}
