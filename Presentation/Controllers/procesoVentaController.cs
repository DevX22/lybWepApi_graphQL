using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/proceso/venta")]
    [ApiController]
    public class procesoVentaController : ControllerBase
    {
        private readonly procesoVentaLogic _logic = new();

        [HttpGet("list")]
        public async Task<IActionResult> getall()
        {
            try
            {
                List<procesoVentaModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] procesoVentaModel req)
        {
            try
            {
                procesoVentaModel res = await _logic.CreateAsync(req);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
