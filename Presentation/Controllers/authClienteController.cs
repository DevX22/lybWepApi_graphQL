using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.response;

namespace Presentation.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class authClienteController : ControllerBase
    {
        private readonly authClienteLogic _logic = new authClienteLogic();

        [HttpPost("auth")]
        public IActionResult post([FromBody] authRequestModel resquest)
        {
            try
            {
                loginResponse response = _logic.authCliente(resquest);
                if (response.token == null)
                {
                    NotFound("Usuario o Contraseña Incorrectos");
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
