using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.response;

namespace Presentation.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    [AllowAnonymous]
    public class authUsuarioController : ControllerBase
    {
        private readonly authUsuarioLogic _logic = new authUsuarioLogic();

        [HttpPost("auth")]
        public IActionResult post([FromBody] authRequestModel request)
        {
            try
            {
                loginResponse response = _logic.authUsuario(request);
                if (!response.success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
