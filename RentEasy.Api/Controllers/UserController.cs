using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentEasy.Api.Services;
using RentEasy.Domain.Commands.Auth;
using RentEasy.Domain.Entities;
using RentEasy.Domain.Handlers;
using RentEasy.Domain.Repositories;
using RentEasy.Shared.Commands;
using System.Threading.Tasks;

namespace RentEasy.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserHandler _userHandler;
        private readonly IUserRepository _userRepository;


        public UserController(UserHandler userHandler, IUserRepository userRepository)
        {
            _userHandler = userHandler;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginUserCommand command)
        {

            var result = await _userHandler.Handler(command);

            if (!result.Success)
                return Ok(result);

            var user = (User)result.Data;

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.CreanPassword();
            var auth = new
            {
                user = user,
                token = token
            };
            return new GenericCommandResult(true, "Usuário Autenticado", auth);
        }

        [Route("")]
        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand userCommand)
        {
            var result = await _userHandler.Handler(userCommand);
            return Ok(result);
        }

        [Route("")]
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromBody] UpdatePasswordCommand updatePassword)
        {
            var result = await _userHandler.Handler(updatePassword);
            return Ok(result);
        }
    }
}
