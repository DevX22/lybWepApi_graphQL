using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Presentation.Controllers
{
    [Route("api/tipocomprobante")]
    [ApiController]
    [Authorize]
    public class tipoComprobanteController : ControllerBase
    {

        private readonly tipoComprobanteLogic _logic = new();

        [HttpGet("list")]
        public async Task<IActionResult> getall()
        {
            try
            {
                List<tipoComprobanteModel> res = await _logic.GetAllAsync();
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> post([FromBody]tipoComprobanteModel req)
        {
            try
            {
                tipoComprobanteModel res = await _logic.CreateAsync(req);
                return Ok(res);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
