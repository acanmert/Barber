using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonServiceController : ControllerBase
    {
        private readonly IServiceManager _services;

        public SalonServiceController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _services.SalonServiceService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetServiceById([FromRoute] int id)
        {
            var service = await _services.SalonServiceService.GetServiceByIdAsync(id);

            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] SalonServiceDtoForInsertion serviceDto)
        {
            await _services.SalonServiceService.CreateServiceAsync(serviceDto);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] SalonServiceDtoForInsertion serviceDto)
        {
            await _services.SalonServiceService.UpdateService(id, serviceDto, false);
            return Ok(serviceDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {
            await _services.SalonServiceService.DeleteService(id, false);
            return NoContent(); // 204 No Content döner, çünkü başarıyla silindiğinde içeriğe gerek yok.
        }
    }
}
