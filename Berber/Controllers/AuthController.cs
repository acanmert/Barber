using Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Berber.Controllers
{
    [ApiController]
    [Route("api/auth")]

    public class Auth : ControllerBase
    {
        private readonly IServiceManager _service;

        public Auth(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost]


        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)

        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }


        [HttpPost("login")]

        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser((user)))
                return Unauthorized();// 401
            var tokenDto = await _service.AuthenticationService.CreateToken(true);

            return Ok(tokenDto);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await _service
                .AuthenticationService
                .RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

    }
}
