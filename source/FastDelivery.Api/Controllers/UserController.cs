using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FastDelivery.Domain.Commands;
using FastDelivery.Domain.Handlers;
using FastDelivery.Shared.ContractsCommand;

namespace FastDelivery.Api.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CommandCreateUser command,
            [FromServices] UserHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(command);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] CommandLoginUser command, [FromServices] UserHandler handler)
        {
            try
            {
                var result = (GenericCommandResult)await handler.Handle(command);

                if (result.Success)
                    return Ok(result);

                return BadRequest(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}