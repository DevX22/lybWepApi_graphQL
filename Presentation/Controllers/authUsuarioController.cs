using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.response;

namespace Presentation.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class authUsuarioController : ControllerBase
    {
        private readonly authUsuarioLogic _logic = new authUsuarioLogic();

        [HttpPost("auth")]
        public IActionResult post([FromBody] authRequestModel request)
        {
            try
            {
                loginResponse response = _logic.authUsuario(request);
                if (response.token == null || response.token == "")
                {
                    return NotFound("Usuario o Contraseña Incorrectos");
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
