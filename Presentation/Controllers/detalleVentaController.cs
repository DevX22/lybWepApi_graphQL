using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/detalleventa")]
    [ApiController]
    [Authorize]
    public class detalleVentaController : ControllerBase
    {
        private readonly detalleVentaLogic _logic = new();

        [HttpGet("getbyventaid/{id}")]
        public async Task<IActionResult> getbyid(int id)
        {
            try
            {
                List<detalleVentaModel> res = await _logic.GetAllByVentaIdAsync(id);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("createmulti")]
        public async Task<IActionResult> post([FromBody] List<detalleVentaModel> req)
        {
            try
            {
                List<detalleVentaModel> res = await _logic.insertMultipleAsyc(req);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
