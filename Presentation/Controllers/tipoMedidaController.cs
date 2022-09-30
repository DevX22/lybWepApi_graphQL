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
        public async Task<IActionResult> get()
        {
            try
            {
                List<tipoMedidaModel> response = await _logic.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tipoMedidaModel req)
        {
            try
            {
                tipoMedidaModel response = await _logic.CreateAsync(req);
                if (response.id == 0)
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

        [HttpPut("update")]
        public async Task<IActionResult> put([FromBody] tipoMedidaModel req)
        {
            try
            {
                tipoMedidaModel res = await _logic.UpdateAsync(req);
                return Ok(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
