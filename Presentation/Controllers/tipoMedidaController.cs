using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tipoMedidaController : ControllerBase
    {
        private tipoMedidaLogic _logic = new tipoMedidaLogic();

        [HttpGet("list")]
        public IActionResult get()
        {
            try
            {
                List<tipoMedidaModel> response = _logic.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public IActionResult post([FromBody] tipoMedidaModel request)
        {
            try
            {
                tipoMedidaModel response = _logic.Create(request);
                if (response.id != 0)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
