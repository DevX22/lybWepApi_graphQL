using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.dto;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        private readonly usuarioLogic _logic = new usuarioLogic();

        [HttpGet("list")]
        public IActionResult get()
        {
            try
            {
                List<usuarioDto> response = _logic.listDetaild();
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
        public IActionResult post([FromBody] usuarioModel request)
        {
            try
            {
                bool success = _logic.Create(request);
                return Ok(success);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("exists")]
        public IActionResult post([FromBody] string usser)
        {
            try
            {
                bool exists = _logic.existsUsuario(usser);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
