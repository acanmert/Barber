using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected readonly IServiceManager _services;

        public UserController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            return Ok(await _services.UserService.GetAllUsersAsync());
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            return Ok(await _services.UserService.GetUserByEmailAsync(email, false));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDtoForInsertion userDto)
        {
            var user = await _services.UserService.CreateUserAsync(userDto);
            return Ok(user);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UserDtoForInsertion userDto)
        {
            await _services.UserService.UpdateUser(id, userDto, false);
            return Ok(userDto);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _services.UserService.DeleteUser(id, false);
            return Ok();
        }

    }
}
