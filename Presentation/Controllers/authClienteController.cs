using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.response;
using Tools;

namespace Presentation.Controllers
{
    [Route("api/cliente")]
    //[Route("api/v{version:apiVersion}/cliente")]
    //[ApiVersion(versionApi.v1)]
    [ApiController]
    
    [AllowAnonymous]
    public class authClienteController : ControllerBase
    {
        private readonly authClienteLogic _logic = new authClienteLogic();

        [HttpPost("auth")]
        public IActionResult post([FromBody] authRequestModel resquest)
        {
            try
            {
                loginResponse response = _logic.authCliente(resquest);
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
