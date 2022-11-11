using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class tipoDocumentoController : ControllerBase
    {
        private readonly tipoDocumentoLogic _logic = new tipoDocumentoLogic();

        [AllowAnonymous]
        [HttpGet("list")]
        public IActionResult get()
        {
            try
            {
                List<tipoDocumentoModel> response = _logic.GetAll();
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public IActionResult post([FromBody] tipoDocumentoModel request)
        {
            try
            {
                tipoDocumentoModel response = _logic.Create(request);
                if (response.id == 0)
                {
                    return BadRequest("No se pudo registrar");
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
