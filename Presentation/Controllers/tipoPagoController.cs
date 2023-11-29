using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers
{
    [Route("api/tipopago")]
    [ApiController]
    [Authorize]
    public class tipoPagoController : ControllerBase
    {
        private readonly tipoPagoLogic _logic = new();

        [HttpGet("list")]
        public async Task<IActionResult> getall()
        {
            try
            {
                List<tipoPagoModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody] tipoPagoModel req)
        {
            try
            {
                tipoPagoModel res = await _logic.CreateAsync(req);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
