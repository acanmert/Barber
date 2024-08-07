using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly IServiceManager _services;

        public BarberController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetBarberAll()
        {
            return Ok( await _services.BarberService.GetAllBarbersAsync());
        }  
        
        [HttpPost]
        public async Task<IActionResult> CreateBarber(BarberDtoForInsertion barberDto)
        {
            return Ok(await _services.BarberService.CreateBarberAsync(barberDto));
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBarber([FromRoute] int id, [FromBody] BarberDtoForInsertion barberDto)
        {
            await _services.BarberService.UpdateBarber(id, barberDto, false);
            return Ok(barberDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBarber([FromRoute] int id)
        {
           await _services.BarberService.DeleteBarber(id, false);
            return Ok();
        }
    }
}
